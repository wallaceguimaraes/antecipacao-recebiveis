using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.Queries
{
    public static class AdvanceRequestQuery
    {
        public static IQueryable<AdvanceRequest> GetByTransferId(this IQueryable<AdvanceRequest> requests, int? transferId)
        {
            return requests.Where(request => request.AdvanceRequestId == transferId);
        }

        public static IQueryable<AdvanceRequest> WhereId(this IQueryable<AdvanceRequest> requests, int? id)
        {
            return requests.Where(request => request.AdvanceRequestId == id);
        }

        public static IQueryable<AdvanceRequest> WhereIds(this IQueryable<AdvanceRequest> requests, List<int> ids)
        {
            return requests.Where(item => ids.Contains(item.AdvanceRequestId));
        }

    }
}