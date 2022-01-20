using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using api.Models.ServiceModel.Interfaces;
using System.Threading.Tasks;
using api.Models.ViewModels;

namespace api.Controllers
{
    [ApiController]
    [Route("api/v2/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
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