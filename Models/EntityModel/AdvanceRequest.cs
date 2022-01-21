using api.Models.EntityModel.Enums;
using System;
using System.Collections.Generic;

namespace api.Models.EntityModel.AdvanceRequest
{
    public class AdvanceRequest
    {
        public AdvanceRequest()
        {
            StartDateAnalysis = DateTime.Now;
            AnalysisEndDate = null;
        }
        public int AdvanceRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime StartDateAnalysis { get; set; }
        public DateTime? AnalysisEndDate { get; set; }
        public AnalysisResult AnalysisResult { get; set; }
        public decimal AmountRequestedAdvance { get; set; }
        public decimal AnticipatedValue { get; set; }
        public ICollection<Transfer> RequestedTransfers { get; set; }

    }
}