using api.Models.EntityModel;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IRequestedAdvance
    {
        Task<IActionResult> getRequestedAdvance(int transferId);
        Task<IActionResult> SaveRequestedTransaction(AdvanceRequest advanceRequest, AdvanceRequestModel vModel);
        Task<IActionResult> ConsultAvailableTransactions();

    }
}