using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.EntityModel
{
    public class Portion
    {
        
        public Portion()
        {
            AnticipatedValue = null;
            TransferDate = null;

        }
        public int PortionId {get; set;}
        public int TransferId {get; set;}
        public Transfer Transfer { get; set; }
        public decimal GrossValue {get; set;}
        public decimal NetValue {get; set;}
        public int InstallmentNumber {get; set;}
        public decimal? AnticipatedValue {get; set;}
        public DateTime ExpectedDateReceipt {get; set;}
        public DateTime? TransferDate {get; set;}



    }
}