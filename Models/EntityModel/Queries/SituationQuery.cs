using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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