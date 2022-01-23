using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IRequestSituation
    {
        Task<IActionResult> SaveSituation(int advanceRequestId, int situationId);
        Task<RequestSituation> StartRequestService(int advanceRequestId);
        Task<IActionResult> ConsultHistory(int situationId);

    }
}