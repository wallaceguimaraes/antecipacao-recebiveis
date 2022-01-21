using api.Models.ServiceModel.Interfaces;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/v2/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPayment _paymentService;
        public PaymentController(IPayment paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Route("make-payment")]
        public async Task<IActionResult> MakePayment(PaymentModel vModel)
        {
            var response = await _paymentService.MakePayment(vModel);

            if (response == null) return null;

            return response;
        }
    }
}