using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.EntityModel
{
    public class RequestedAdvance
    {
        public int RequestedAdvanceId { get; set; }
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
        public int AdvanceRequestId { get; set; }
        public AdvanceRequest AdvanceRequest { get; set; }

    }
}