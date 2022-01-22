using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Models.EntityModel.Queries
{
    public static class AdvanceRequestQuery
    {
        public static IQueryable<AdvanceRequest> GetByTransferId(this IQueryable<AdvanceRequest> requests, int? transferId)
        {
            return requests.Where(request => request.AdvanceRequestId == transferId);
        }
    }
}