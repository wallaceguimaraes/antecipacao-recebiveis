using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.ResultModel
{
    public class RequestedAdvanceListJson : IActionResult
    {
         public RequestedAdvanceListJson() { }

        public RequestedAdvanceListJson(IEnumerable<RequestedAdvance> requestedAdvances)
        {
            RequestedAdvances = requestedAdvances.Select(requestedAdvance => new RequestedAdvanceJson(requestedAdvance)).ToList();
        }
        public IEnumerable<RequestedAdvanceJson> RequestedAdvances { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
         
        
    }
}