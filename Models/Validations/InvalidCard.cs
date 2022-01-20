using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Validations
{
    public sealed class InvalidCard : CreditCardError
    {
        public InvalidCard()
        {
            ErrorMessage = "Cartão de crédito inválido!";
        }
        
    }
}