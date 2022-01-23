using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.Models.EntityModel;


namespace api.Models.ResultModel
{
    public class SituationListJson : IActionResult
    {
        public SituationListJson() { }

        public SituationListJson(IEnumerable<Situation> situations)
        {
            Situations = situations.Select(situation => new SituationJson(situation)).ToList();
        }
        
        public IEnumerable<SituationJson> Situations { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
        
    }
}