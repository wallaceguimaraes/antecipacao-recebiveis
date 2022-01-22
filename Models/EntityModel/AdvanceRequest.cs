using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel.Enums;

namespace api.Models.EntityModel
{
    public class AdvanceRequest
    {
        public AdvanceRequest()
        {
            RequestDate = DateTime.Now;
            StartDateAnalysis = null;
            AnalysisEndDate = null;
            AnalysisResult = null;
        }
        public int AdvanceRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? StartDateAnalysis { get; set; }
        public DateTime? AnalysisEndDate { get; set; }
        public AnalysisResult? AnalysisResult { get; set; }
        public decimal AmountRequestedAdvance { get; set; }
        public decimal? AnticipatedValue { get; set; }
        public ICollection<RequestedAdvance> RequestedAdvances { get; set; }
        public ICollection<RequestSituation> RequestedSituations { get; set; }



    }
}