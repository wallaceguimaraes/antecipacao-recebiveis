using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;
using api.Models.EntityModel.Enums;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class AdvanceRequestJson : IActionResult
    {
        public AdvanceRequestJson() { }

        public AdvanceRequestJson(AdvanceRequest advanceRequest)
        {
            AdvanceRequestId = advanceRequest.AdvanceRequestId;
            RequestDate = advanceRequest.RequestDate;
            StartDateAnalysis = advanceRequest.StartDateAnalysis;
            AnalysisEndDate = advanceRequest.AnalysisEndDate;
            AnalysisResult = advanceRequest.AnalysisResult;
            AmountRequestedAdvance = advanceRequest.AmountRequestedAdvance;
            AnticipatedValue = advanceRequest.AnticipatedValue;
            RequestedTransfers = advanceRequest.RequestedTransfers;
        }

        public int AdvanceRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? StartDateAnalysis { get; set; }
        public DateTime? AnalysisEndDate { get; set; }
        public AnalysisResult? AnalysisResult { get; set; }
        public decimal AmountRequestedAdvance { get; set; }
        public decimal? AnticipatedValue { get; set; }
        public ICollection<Transfer> RequestedTransfers { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }


    }
}