using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel.Interfaces
{
    public interface ITransfer
    {
        Task<IActionResult> List();

        Task<IActionResult> SaveTransfer(PaymentModel vModel, string status);
    
        Task<IActionResult> ConsultTransaction(int id);

        Task<IActionResult> DisapproveTransaction(int id);

        Task<IActionResult> ApproveTransaction(int id);

        Task<ICollection<Transfer>> PickUpUnfinishedTransactions(ApproveOrDisapproveModel vModel);

    }
}