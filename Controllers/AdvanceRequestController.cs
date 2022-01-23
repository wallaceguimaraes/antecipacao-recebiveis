using api.Models.EntityModel;
using api.Models.ServiceModel.Interfaces;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/v2/advance-request")]
    public class AdvanceRequestController : Controller
    {
        private readonly IAdvanceRequest _advanceRequestService;
        public AdvanceRequestController(IAdvanceRequest advanceRequestService)
        {
            _advanceRequestService = advanceRequestService;
        }

        [HttpPost]
        [Route("request")]
        public async Task<IActionResult> AdvanceRequest(AdvanceRequestModel vModel)
        {
            return await _advanceRequestService.AdvanceRequest(vModel);
        }

        [HttpGet]
        [Route("consult-available-transactions")]
        public async Task<IActionResult> ConsultAvailableTransactions()
        {
            return await _advanceRequestService.ConsultAvailableTransactions();
        }

        [HttpPut]
        [Route("start-request-service")]
        public async Task<RequestSituation> StartRequestService(StartRequestServiceModel vModel)
        {
            return await _advanceRequestService.StartRequestService(vModel);
        }

        [HttpPut]
        [Route("approve-disapprove")]
        public async Task<RequestedAdvance[]> ApproveOrDisapprove(ApproveOrDisapproveModel vModel)
        {
            return await _advanceRequestService.ApproveOrDisapprove(vModel);
        }

        [HttpPost]
        [Route("consult-history")]
        public async Task<IActionResult> ConsultHistory(HistoryAnticipationsModel vModel)
        {
            return await _advanceRequestService.ConsultHistory(vModel);
        }

    }
}