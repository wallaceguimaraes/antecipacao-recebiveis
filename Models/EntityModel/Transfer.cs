using System;
using System.Collections.Generic;

namespace api.Models.EntityModel
{
    public class Transfer
    {
        public Transfer()
        {
            DateTransferMade = DateTime.Now;
            FixedRate = 0.90m;
            Early = null;
        }
        public int TransferId { get; set; }
        public DateTime DateTransferMade { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? DisapprovalDate { get; set; }
        public bool? Early { get; set; }
        public string ConfirmationAcquirer { get; set; }
        public decimal GrossTransferAmount { get; set; }
        public decimal TransferNetAmount { get; set; }
        public decimal FixedRate { get; set; }
        public int InstallmentAmount { get; set; }
        public string CardDigits { get; set; }
        public ICollection<Portion> Portions { get; set; }

        public RequestedAdvance RequestedAdvance { get; set; }

    }
}