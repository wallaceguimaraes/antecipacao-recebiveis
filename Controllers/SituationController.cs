using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models.EntityModel;
using api.Models.ResultModel;
using api.Models.ServiceModel.Interfaces;


using api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/v2/situations")]
    public class SituationController : Controller
    {
        private readonly ISituationService _situationService;
        public SituationController(ISituationService situationService)
        {
            _situationService = situationService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var situations = await _situationService.List();

            return situations;
        }
    }
}