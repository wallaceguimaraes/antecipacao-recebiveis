using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.EntityModel;
using api.Models.EntityModel.Queries;
using api.Models.ResultModel;
using api.Models.ServiceModel.Interfaces;
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


        public async Task<IActionResult> getRequestedAdvance(int transferId)
        {
            var requestedAdvances = _context.RequestedAdvances.searchByTransferId(transferId).FirstOrDefault();
            if (requestedAdvances == null){
                return null;
            } 

            var requested = _context.RequestedAdvances.searchByTransferId(transferId);

            return new RequestedAdvanceListJson(requested);
        }
 

    }
}