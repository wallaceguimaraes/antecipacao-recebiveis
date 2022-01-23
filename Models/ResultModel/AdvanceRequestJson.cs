using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            RequestedAdvances = advanceRequest.RequestedAdvances;
            RequestedSituations = advanceRequest.RequestedSituations;
        }

        public int AdvanceRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? StartDateAnalysis { get; set; }
        public DateTime? AnalysisEndDate { get; set; }
        public string? AnalysisResult { get; set; }
        public decimal AmountRequestedAdvance { get; set; }
        public decimal? AnticipatedValue { get; set; }
        public ICollection<RequestedAdvance> RequestedAdvances { get; set; }
        public ICollection<RequestSituation> RequestedSituations { get; set; }


        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }


    }
}