using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Models.ServiceModel.Interfaces;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public  async Task<IActionResult> AdvanceRequest(AdvanceRequestModel vModel)
        {
           return await _advanceRequestService.AdvanceRequest(vModel);
        }
    }
}