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
    [Route("api/v2/transfer")]
    public class TransferController : Controller
    {
       private readonly ITransferService _transferService;
        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
       /*      try
            { */
                var transfers = await _transferService.List();

                if (transfers == null) return null;

                return transfers;

          /*   }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            } */
        }
    }
}