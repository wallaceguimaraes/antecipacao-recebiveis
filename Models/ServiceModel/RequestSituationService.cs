using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.EntityModel;
using api.Models.ServiceModel.Interfaces;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel
{
    public class RequestSituationService : IRequestSituation
    {
        private readonly DataContext _context;

        public RequestSituationService(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> SaveSituation(int advanceRequestId, int situationId)
        {
            RequestSituation requestSituation = new RequestSituation();
            requestSituation.AdvanceRequestId = advanceRequestId;
            requestSituation.SituationId = situationId;
            _context.Add(requestSituation);

  
                await _context.SaveChangesAsync();

    
            return null;
        }

    }
}