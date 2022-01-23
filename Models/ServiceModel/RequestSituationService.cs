using System;
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
    public class RequestSituationService : IRequestSituation
    {
        private readonly DataContext _context;

        public RequestSituationService(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ConsultHistory(int situationId)
        {
            ICollection<RequestSituation> situations = _context.RequestSituations.GetHistoryAdvanceRequest(situationId).ToList();

            //List<AdvanceRequest> advanceRequests = null;
            var advanceRequestIds = new List<int>{};
            foreach (var situation in situations)
            {
             advanceRequestIds.Add(situation.AdvanceRequestId);
            }
            var list = _context.AdvanceRequests.WhereIds(advanceRequestIds);

            return new AdvanceRequestLisJson(list);
        }

        public async Task<IActionResult> SaveSituation(int advanceRequestId, int situationId)
        {
            RequestSituation requestSituation = new RequestSituation();
            requestSituation.AdvanceRequestId = advanceRequestId;
            requestSituation.SituationId = situationId;

            if (situationId == 2)
            {
                _context.Add(requestSituation);
            }
            else
            {
                requestSituation.EndDate = DateTime.Now;
                _context.Update(requestSituation);

            }
            await _context.SaveChangesAsync();


            return null;
        }


        public async Task<RequestSituation> StartRequestService(int advanceRequestId)
        {
            RequestSituation requestSituation = _context.RequestSituations.Where(requestSituation => requestSituation.AdvanceRequestId == advanceRequestId
                                               && requestSituation.EndDate == null && requestSituation.SituationId == 1).FirstOrDefault();

            if (requestSituation == null) return null;
            //UNDER ANALYSIS
            requestSituation.SituationId = 2;

            _context.Update(requestSituation);

            await _context.SaveChangesAsync();

            return requestSituation;
        }

    }
}