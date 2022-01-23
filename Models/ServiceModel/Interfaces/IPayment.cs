using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IPayment
    {
        Task<IActionResult> MakePayment(PaymentModel vModel);

    }
}