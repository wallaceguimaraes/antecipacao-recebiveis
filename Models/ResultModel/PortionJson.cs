using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

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
            PlotNumber = portion.PlotNumber;
            AnticipatedValue = portion.AnticipatedValue;
            ExpectedDateReceipt = portion.ExpectedDateReceipt;
            TransferDate = portion.TransferDate;
           
        }
        public int PortionId { get; set; }
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
        public int PlotNumber { get; set; }
        public decimal? AnticipatedValue { get; set; }
        public DateTime? ExpectedDateReceipt { get; set; }
        public DateTime? TransferDate { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}