using api.Models.EntityModel;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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