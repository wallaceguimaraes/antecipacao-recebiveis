using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.EntityModel;
using api.Models.EntityModel.Enums;
using api.Models.EntityModel.Queries;
using api.Models.ResultModel;
using api.Models.ServiceModel.Interfaces;
using api.Models.Validations;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        /*
        TABELA PORTION -> AnticipatedValue
        Valor antecipado (Esse campo só deve ser preenchido se a transação for aprovada pela análise 
        do financeiro, na solicitação de antecipação);

        Data em que a parcela foi repassada (Esse campo só deve ser preenchido se a transação for 
        aprovada pela análise do financeiro, na solicitação de antecipação).



        SOLICITAÇÕES DE ANTECIPAÇÃO SÃO DOCUMENTOS EMITIDOS PELO LOJISTA/VENDEDOR ATRAVÉS DO
        NOSSO SERVIÇO DE REPASSE ANTECIPADO DE  VALORES. A antecipação de uma transação tem um 
        CUSTO de 3.8% APLICADO em CADA PARCELA da TRANSAÇÃO, se APROVADA pela análise do financeiro, 
        sendo automaticamente debitado no seu repasse. Considerando o exemplo da transação citado na 
        fase 1, se cada parcela da transação tem valor líquido de 49,55, o valor antecipado da parcela 
        seria obtido a partir desse valor líquido, debitado a taxa de 3.8%.

        CRITÉRIOS DE ACEITAÇÃO
          
            OBS: Para realização de uma nova solicitação de antecipação, é necessário que a solicitação atual já tenha sido FINALIZADA;
            
        */


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


        /*


      ROTAS


      4° Endpoint -> Aprovar ou reprovar uma ou mais transações da antecipação (quando todas as transações forem finalizadas, 
      a antecipação será finalizada);
      5° Endpoint -> Consultar histórico de antecipações com filtro por status (pendente, em análise, finalizada).

      */
        /*
         EM ANÁLISE: A equipe financeira iniciou a análise da antecipação, podendo aprovar ou reprovar UMA ou MAIS 
              TRANSAÇÕES contidas na SOLICITAÇÃO;
        */



        public async Task<IActionResult> ConsultAvailableTransactions()
        {
            var list = await _requestedAdvanceService.ConsultAvailableTransactions();

            return list;
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
