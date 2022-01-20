using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.EntityModel.Queries
{
    public static class TransferQuery
    {
        public static IQueryable<Transfer> OrderById(this IQueryable<Transfer> transfers)
        {
            return transfers.OrderBy(transfer => transfer.TransferId);
        }
    }
}