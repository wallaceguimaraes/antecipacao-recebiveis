using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace api.Models.ResultModel
{
 
    public class SituationJson : IActionResult
    {
         public SituationJson() { }

        public SituationJson(Situation situation)
        {
            SituationId = situation.SituationId;
            Description = situation.Description;
        }

        public int SituationId { get; set; }
        public string Description { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
    
}