using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.EntityModel
{
    public class Transfer
    {
        public Transfer()
        {
            DateTransferMade = DateTime.Now;
            FixedRate = 0.90m;
        }
        public int TransferId { get; set; }
        public DateTime DateTransferMade { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? DisapprovalDate { get; set; }
        public bool Early { get; set; }
        public string ConfirmationAcquirer { get; set; }
        public decimal GrossTransferAmount { get; set; }
        public decimal TransferNetAmount { get; set; }
        public decimal FixedRate { get; set; }
        public int NumberPlots { get; set; }
        public string CardDigits { get; set; }
        public ICollection<Portion> Portions { get; set; }

    }
}