using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace api.Models.EntityModel.Queries
{
    public static class RequestedAdvanceQuery
    {
        public static IQueryable<RequestedAdvance> searchByTransferId(this IQueryable<RequestedAdvance> requestedAdvances, int transferId)
        {
            return requestedAdvances.Where(requestedAdvance => requestedAdvance.TransferId == transferId).AsNoTracking();
        }

        public static IQueryable<RequestedAdvance> searchByUnavailableTransfers(this IQueryable<RequestedAdvance> requestedAdvances)
        {
            return requestedAdvances.OrderBy(requestedAdvance => requestedAdvance.RequestedAdvanceId).AsNoTracking();
        }

        public static IQueryable<Transfer> searchByAvailableTransfers(this IQueryable<Transfer> transfers, List<int> transferIds)
        {
            // persons.Where(p => p.Locations.Any(l => searchIds.Contains(l.Id)));
            return transfers.Where(x => !transferIds.Contains(x.TransferId)).AsNoTracking();
        }

        public static IQueryable<RequestedAdvance> PickUpUnfinishedTransactions(this IQueryable<RequestedAdvance> requesteds, int? id)
        {
            return requesteds.Where(r => r.AdvanceRequestId == id).Include(b => b.Transfer.Early == null);

        }


    }

}