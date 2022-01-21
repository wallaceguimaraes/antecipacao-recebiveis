using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.Queries
{
    public static class PortionQuery
    {
          public static IQueryable<Portion> OrderById(this IQueryable<Portion> portions)
        {
            return portions.OrderBy(portion => portion.PortionId);
            //.Include(portion => portion.Transfer)
        }
           public static IQueryable<Portion> GetByTransferId(this IQueryable<Portion> portions, int? transferId)
        {
            return portions.Where(portion => portion.TransferId == transferId);
            //.Include(portion => portion.Transfer)
        }
    }
}