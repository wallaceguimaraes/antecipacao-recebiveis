using System.Linq;
using Microsoft.EntityFrameworkCore;

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
    }
}