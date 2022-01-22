using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IAdvanceRequest
    {
        
        Task<IActionResult> ConsultAvailableTransactions();
        Task<IActionResult> AdvanceRequest(AdvanceRequestModel vModel);
    }
}