using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IRequestedAdvance
    {
        Task<IActionResult> getRequestedAdvance(int transferId);

    }
}