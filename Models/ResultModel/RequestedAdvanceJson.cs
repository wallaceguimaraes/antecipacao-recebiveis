using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Models.ResultModel
{
    public class RequestedAdvanceJson : IActionResult
    {
        public RequestedAdvanceJson() { }

        public RequestedAdvanceJson(RequestedAdvance requestedAdvance)
        {
            RequestedAdvanceId = requestedAdvance.RequestedAdvanceId;
            TransferId = requestedAdvance.TransferId;
            Transfer = requestedAdvance.Transfer;
            AdvanceRequestId = requestedAdvance.AdvanceRequestId;
            AdvanceRequest = requestedAdvance.AdvanceRequest;
        }

        public int RequestedAdvanceId { get; set; }
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
        public int AdvanceRequestId { get; set; }
        public AdvanceRequest AdvanceRequest { get; set; }


        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }

    }
}