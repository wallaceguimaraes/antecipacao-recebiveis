using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.EntityModel.Queries
{
    public static class RequestedAdvanceQuery
    {
          public static IQueryable<RequestedAdvance> searchByTransferId(this IQueryable<RequestedAdvance> requestedAdvances, int transferId)
        {
            return requestedAdvances.Where(requestedAdvance => requestedAdvance.TransferId == transferId);
        }
    }
}