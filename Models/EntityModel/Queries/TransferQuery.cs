using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Models.EntityModel.Queries
{
    public static class TransferQuery
    {
        public static IQueryable<Transfer> OrderById(this IQueryable<Transfer> transfers)
        {
            return transfers.OrderBy(transfer => transfer.TransferId).Include(transfer => transfer.Portions);
        }
        public static IQueryable<Transfer> WhereId(this IQueryable<Transfer> transfers, int id)
        {
            return transfers.OrderBy(transfer => transfer.TransferId).Where(transfer => transfer.TransferId == id).Include(transfer => transfer.Portions);
        }

        public static IQueryable<Transfer> WhereIdAndEarlyNull(this IQueryable<Transfer> transfers, int id)
        {
            return transfers.OrderBy(transfer => transfer.TransferId).Where(transfer => transfer.TransferId == id && transfer.Early == null).Include(transfer => transfer.Portions);
        }
        public static IQueryable<RequestedAdvance> GetRequestedAdvanceByIdWithtransactions(this IQueryable<RequestedAdvance> requesteds, int id)
        {
            return requesteds.OrderBy(requested => requested.RequestedAdvanceId).Where(requested => requested.RequestedAdvanceId == id).Include(reques => reques.Transfer);
        }

    }
}