using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Validations
{
    public sealed class PreviouslyRequestedTransactionError : RequestFailure
    {
        public PreviouslyRequestedTransactionError(int solicitacaoId)
        {
            ErrorMessage = $"The request is not allowed because the with NSU {solicitacaoId} transaction has already been requested before!";
        }
        
    }
}