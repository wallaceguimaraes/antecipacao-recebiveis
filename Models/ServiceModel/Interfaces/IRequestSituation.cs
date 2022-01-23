using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IRequestSituation
    {
        Task<IActionResult> SaveSituation(int advanceRequestId, int situationId);
        Task<RequestSituation> StartRequestService(int advanceRequestId);
        Task<IActionResult> ConsultHistory(int situationId);

    }
}