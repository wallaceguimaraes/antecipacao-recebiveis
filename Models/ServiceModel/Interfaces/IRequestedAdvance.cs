using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IRequestedAdvance
    {
        Task<IActionResult> getRequestedAdvance(int transferId);
        Task<IActionResult> SaveRequestedTransaction(AdvanceRequest advanceRequest, AdvanceRequestModel vModel);
        Task<IActionResult> ConsultAvailableTransactions();

    }
}