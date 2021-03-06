using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Models.ResultModel
{
    public class PortionJson : IActionResult
    {
        public PortionJson() { }

        public PortionJson(Portion portion)
        {
            PortionId = portion.PortionId;
            TransferId = portion.TransferId;
            Transfer = portion.Transfer;
            GrossValue = portion.GrossValue;
            NetValue = portion.NetValue;
            installmentNumber = portion.InstallmentNumber;
            AnticipatedValue = portion.AnticipatedValue;
            ExpectedDateReceipt = portion.ExpectedDateReceipt;
            TransferDate = portion.TransferDate;
           
        }
        public int PortionId { get; set; }
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
        public int installmentNumber { get; set; }
        public decimal? AnticipatedValue { get; set; }
        public DateTime? ExpectedDateReceipt { get; set; }
        public DateTime? TransferDate { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}