using api.Models.ServiceModel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/v2/portions")]
    public class PortionController : Controller
    {
        private readonly IPortion _portionService;
        public PortionController(IPortion portionService)
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