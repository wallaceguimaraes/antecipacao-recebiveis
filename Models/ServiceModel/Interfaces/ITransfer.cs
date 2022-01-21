using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel.Interfaces
{
    public interface ITransfer
    {
        Task<IActionResult> List();

        Task<IActionResult> SaveTransfer(PaymentModel vModel, string status);
    }
}