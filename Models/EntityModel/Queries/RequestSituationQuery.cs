using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.EntityModel.Queries
{
    public static class RequestSituationQuery
    {
    public static IQueryable<RequestSituation> GetSituationByAdvanceRequest(this IQueryable<RequestSituation> requestSituations , int? advanceRequestId)
        {
            return requestSituations.Where(requestSituation => requestSituation.AdvanceRequestId == advanceRequestId 
                                                && requestSituation.EndDate == null && requestSituation.SituationId == 1);
        }



    }
}