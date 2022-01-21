using System.Linq;

namespace api.Models.EntityModel.Queries
{
    public static class SituationQuery
    {
        public static IQueryable<Situation> OrderByDescription(this IQueryable<Situation> situations)
        {
            return situations.OrderBy(situation => situation.Description);
        }
    }
}