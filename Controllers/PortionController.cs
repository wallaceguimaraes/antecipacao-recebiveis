using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Models.ServiceModel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/v2/portions")]
    public class PortionController : Controller
    {
        private readonly IPortionService _portionService;
        public PortionController(IPortionService portionService)
        {
            _portionService = portionService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var portions = await _portionService.List();

            return portions;
        }
    }
}