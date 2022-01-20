using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel.Enums;


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

        public void FinishAnalysis(){
            if(AnalysisEndDate == null)
                AnalysisEndDate = DateTime.Now;
            else
                throw new Exception($"Solicitação já concluída em: {AnalysisEndDate?.ToString("dd/MM/'yyyy hh:mm")}");
        }


    }
}