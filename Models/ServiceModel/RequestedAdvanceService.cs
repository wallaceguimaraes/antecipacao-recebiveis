using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.EntityModel;
using api.Models.EntityModel.Queries;
using api.Models.ResultModel;
using api.Models.ServiceModel.Interfaces;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel
{
    public class RequestedAdvanceService : IRequestedAdvance
    {
        private readonly DataContext _context;

        public RequestedAdvanceService(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> SaveRequestedTransaction(AdvanceRequest advanceRequest, AdvanceRequestModel vModel)
        {
            foreach (var transfer in vModel.Transfers)
            {
                RequestedAdvance requestedAdvance = new RequestedAdvance();
                requestedAdvance.AdvanceRequestId = advanceRequest.AdvanceRequestId;
                requestedAdvance.TransferId = transfer.TransferId;

                _context.Add(requestedAdvance);

                await _context.SaveChangesAsync();
            }

            return null;
        }


        public async Task<IActionResult> getRequestedAdvance(int transferId)
        {
            var requestedAdvances = _context.RequestedAdvances.searchByTransferId(transferId).FirstOrDefault();
            //int id = requestedAdvances.AdvanceRequestId;
            if (requestedAdvances == null)
            {
                return null;
            }

            var requested = _context.RequestedAdvances.searchByTransferId(transferId);

            return new RequestedAdvanceListJson(requested);
        }

        public async Task<IActionResult> ConsultAvailableTransactions()
        {
            //var count = _context.RequestedAdvances.searchByUnavailableTransfers().Count();
            var Transfers = _context.RequestedAdvances.searchByUnavailableTransfers().ToList();
            //int id = requestedAdvances.AdvanceRequestId;

            if (Transfers != null)
            {
                List<int> transferIds = new List<int>();

                foreach (var transfer in Transfers)
                {
                    transferIds.Add(transfer.TransferId);
                }

                var availableTransfers = _context.Transfers.searchByAvailableTransfers(transferIds);
                return new TransferListJson(availableTransfers);

            }

            return null;
        }
    }
}