using System;
using System.Collections.Generic;
using System.Linq;
using api.Models.EntityModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


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