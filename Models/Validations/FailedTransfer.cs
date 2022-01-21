using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Validations
{
    public sealed class FailedTransfer : FailedTransaction
    {
        public FailedTransfer()
        {
            ErrorMessage = "A transação foi reprovada!";
        }
        
        
    }
}