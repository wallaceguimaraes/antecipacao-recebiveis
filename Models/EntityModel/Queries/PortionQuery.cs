using System.Linq;

namespace api.Models.EntityModel.Queries
{
    public static class PortionQuery
    {
        public static IQueryable<Portion> OrderById(this IQueryable<Portion> portions)
        {
            return portions.OrderBy(portion => portion.PortionId);
        }
        public static IQueryable<Portion> GetByTransferId(this IQueryable<Portion> portions, int? transferId)
        {
            return portions.Where(portion => portion.TransferId == transferId);
        }
    }
}