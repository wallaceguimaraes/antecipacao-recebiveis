using api.Infrastructure.Context;
using api.Models.EntityModel;
using api.Models.EntityModel.Queries;
using api.Models.ResultModel;
using api.Models.ServiceModel.Interfaces;
using api.Models.Validations;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.ServiceModel
{
    public class AdvanceRequestService : IAdvanceRequest
    {
        private readonly DataContext _context;
        private readonly IPortion _portionService;
        private readonly IRequestedAdvance _requestedAdvanceService;
        private readonly ITransfer _transferService;
        private readonly IRequestSituation _requestSituationService;


        public AdvanceRequestService(DataContext context, IPortion portionService,
                                    IRequestedAdvance requestedAdvanceService,
                                    ITransfer transferService,
                                    IRequestSituation requestSituationService)
        {
            _context = context;
            _portionService = portionService;
            _requestedAdvanceService = requestedAdvanceService;
            _transferService = transferService;
            _requestSituationService = requestSituationService;

        }

        public async Task<IActionResult> AdvanceRequest(AdvanceRequestModel vModel)
        {
            foreach (var transfer in vModel.Transfers)
            {
                var list = await _requestedAdvanceService.getRequestedAdvance(transfer.TransferId);
                //1° - Não é permitido incluir em uma NOVA SOLICITAÇÃO DE ANTECIPAÇÃO, transações solicitadas anteriormente;
                if (list != null)
                {
                    return new PreviouslyRequestedTransactionError(transfer.TransferId);
                }
            }
            decimal netValue = 0;
            AdvanceRequest advanceRequest = new AdvanceRequest();

            foreach (var transfer in vModel.Transfers)
            {
                netValue = netValue + transfer.TransferNetAmount;
            }

            advanceRequest.AmountRequestedAdvance = netValue;

            _context.Add(advanceRequest);

            await _context.SaveChangesAsync();
            await _requestedAdvanceService.SaveRequestedTransaction(advanceRequest, vModel);

            //SItuationId => 1 PENDENTE
            await _requestSituationService.SaveSituation(advanceRequest.AdvanceRequestId, 1);

            return new AdvanceRequestJson(advanceRequest);

        }

        public async Task<RequestedAdvance[]> ApproveOrDisapprove(ApproveOrDisapproveModel vModel)
        {
            if (vModel.Status == "disapprove")
            {
                foreach (var transfer in vModel.Transfers)
                {
                    await _transferService.DisapproveTransaction(transfer.TransferId);
                }
            }
            else if (vModel.Status == "approve")
            {
                foreach (var transfer in vModel.Transfers)
                {
                    await _transferService.ApproveTransaction(transfer.TransferId);
                    await _portionService.UpdatePortion(transfer.TransferId, transfer.TransferNetAmount);
                }
            }
            //Verificar se AdvanceRequest Teve todas suas transferencias finalizadas Early diferente de null
            ICollection<Transfer> transaction = await _transferService.PickUpUnfinishedTransactions(vModel);

            bool approve = false;
            bool disapprove = false;
            bool endRequest = true;

            foreach (var transf in transaction)
            {
                switch (transf.Early)
                {
                    case "N":
                        disapprove = true;
                        break;
                    case "S":
                        approve = true;
                        break;
                    case null:
                        endRequest = false;
                        break;
                    default:

                        break;
                }
            }
            AdvanceRequest advanceRequest = _context.AdvanceRequests.WhereId(vModel.AdvanceRequestId).FirstOrDefault();

            if (approve == true && disapprove == false && endRequest == true)
            {
                advanceRequest.AnalysisResult = "APROVADA";

                _context.Update(advanceRequest);
                await _context.SaveChangesAsync();
            }
            else if (approve == false && disapprove == true && endRequest == true)
            {
                await _requestSituationService.SaveSituation(vModel.AdvanceRequestId, 3);
                advanceRequest.AnalysisResult = "REPROVADA";
            }
            else if ((approve == true && disapprove == true && endRequest == true))
            {
                //NOT END REQUEST   
                advanceRequest.AnalysisResult = "APROVADA PARCIALMENTE";
            }

            if (endRequest == true)
            {
                _context.Update(advanceRequest);
                await _context.SaveChangesAsync();

                await _requestSituationService.SaveSituation(vModel.AdvanceRequestId, 3);

                foreach (var transfer in vModel.Transfers)
                {
                    await _portionService.EndDate(transfer.TransferId);
                }
            }

            return null;
        }



        public async Task<IActionResult> ConsultAvailableTransactions()
        {
            var list = await _requestedAdvanceService.ConsultAvailableTransactions();

            return list;
        }

   
         public async Task<IActionResult> ConsultHistory(HistoryAnticipationsModel vModel)
        {
            return await _requestSituationService.ConsultHistory(vModel.SituationId);
        }


        public async Task<RequestSituation> StartRequestService(StartRequestServiceModel vModel)
        {
            var requestSituation = await _requestSituationService.StartRequestService(vModel.AdvanceRequest.AdvanceRequestId);

            if (requestSituation == null)
            {
                return null;
            }

            AdvanceRequest advanceRequest = _context.AdvanceRequests.WhereId(vModel.AdvanceRequest.AdvanceRequestId).FirstOrDefault();
            advanceRequest.StartDateAnalysis = DateTime.Now;
            _context.Update(advanceRequest);
            await _context.SaveChangesAsync();

            return requestSituation;
        }

     
    }
}
