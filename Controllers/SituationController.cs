using api.Models.ServiceModel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/v2/situations")]
    public class SituationController : Controller
    {
        private readonly ISituation _situationService;
        public SituationController(ISituation situationService)
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