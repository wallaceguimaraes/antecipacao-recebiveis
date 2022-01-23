using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.Queries
{
    public static class RequestSituationQuery
    {
    public static IQueryable<RequestSituation> GetSituationByAdvanceRequest(this IQueryable<RequestSituation> requestSituations , int? advanceRequestId)
        {
            return requestSituations.Where(requestSituation => requestSituation.AdvanceRequestId == advanceRequestId 
                                                && requestSituation.EndDate == null && requestSituation.SituationId == 1);
        }

     public static IQueryable<RequestSituation> GetHistoryAdvanceRequest (this IQueryable<RequestSituation> requestedSituations, int? situationId)
        {
            return requestedSituations.Where(rs => rs.SituationId == situationId).Include(b => b.AdvanceRequest);

        }


    }
}