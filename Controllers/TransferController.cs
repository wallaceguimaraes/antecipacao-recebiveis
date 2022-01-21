using api.Models.ServiceModel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/v2/transfer")]
    public class TransferController : Controller
    {
        private readonly ITransfer _transferService;
        public TransferController(ITransfer transferService)
        {
            _transferService = transferService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var transfers = await _transferService.List();

            if (transfers == null) return null;

            return transfers;
        }

        [HttpGet]
        [Route("consult-transaction/{id:int}")]
        public async Task<IActionResult> ConsultTransaction(int id)
        {

            var transfers = await _transferService.ConsultTransaction(id);

            if (transfers == null) return null;

            return transfers;
        }
    }
}