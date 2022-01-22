using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.EntityModel
{
    public class RequestSituation
    {
        public RequestSituation()
        {
            this.StartDate = DateTime.Now;
            
        }

        public int RequestSituationId { get; set; }
        public int AdvanceRequestId { get; set; }
        public AdvanceRequest AdvanceRequest { get; set; }
        public int SituationId { get; set; }
        public Situation Situation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}