using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.ResultModel
{
    public class AdvanceRequestLisJson : IActionResult
    {
        public AdvanceRequestLisJson() { }

        public AdvanceRequestLisJson(IEnumerable<AdvanceRequest> advanceRequests)
        {
            AdvanceRequests = advanceRequests.Select(advanceRequest => new AdvanceRequestJson(advanceRequest)).ToList();
        }

        public IEnumerable<AdvanceRequestJson> AdvanceRequests { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }

    }
}