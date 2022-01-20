using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class PortionListJson : IActionResult
    {
         public PortionListJson() { }

        public PortionListJson(IEnumerable<Portion> portions)
        {
            Portions = portions.Select(portion => new PortionJson(portion)).ToList();
        }
        
        public IEnumerable<PortionJson> Portions { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
         
    }
}