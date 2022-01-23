using api.Models.EntityModel;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IAdvanceRequest
    {

        Task<IActionResult> ConsultAvailableTransactions();
        Task<IActionResult> AdvanceRequest(AdvanceRequestModel vModel);
        Task<RequestSituation> StartRequestService(StartRequestServiceModel vModel);
        Task<RequestedAdvance[]> ApproveOrDisapprove(ApproveOrDisapproveModel vModel);
        Task<IActionResult> ConsultHistory(HistoryAnticipationsModel vModel);
    }
}