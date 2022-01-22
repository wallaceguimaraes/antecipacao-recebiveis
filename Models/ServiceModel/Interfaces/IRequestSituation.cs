using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IRequestSituation
    {
        Task<IActionResult> SaveSituation(int advanceRequestId, int situationId);

    }
}