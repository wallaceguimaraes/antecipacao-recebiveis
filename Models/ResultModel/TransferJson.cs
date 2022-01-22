using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;


namespace api.Models.ResultModel
{
    public class TransferJson : IActionResult
    {
        public TransferJson() { }

        public TransferJson(Transfer transfer)
        {
            TransferId = transfer.TransferId;
            DatetransferMade = transfer.DateTransferMade;
            ApprovalDate = transfer.ApprovalDate;
            DisapprovalDate = transfer.DisapprovalDate;
            Early = transfer.Early;
            ConfirmationAcquirer = transfer.ConfirmationAcquirer;
            GrossTransferAmount = transfer.GrossTransferAmount;
            transferNetAmount = transfer.TransferNetAmount;
            FixedRate = transfer.FixedRate;
            InstallmentAmount = transfer.InstallmentAmount;
            CardDigits = transfer.CardDigits;
            Portions = transfer.Portions;
        }

        public int TransferId { get; set; }
        public DateTime DatetransferMade { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? DisapprovalDate { get; set; }
        public string? Early { get; set; }
        public string ConfirmationAcquirer { get; set; }
        public decimal GrossTransferAmount { get; set; }
        public decimal transferNetAmount { get; set; }
        public decimal FixedRate { get; set; }
        public int InstallmentAmount { get; set; }
        public string CardDigits { get; set; }
        public ICollection<Portion> Portions { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}