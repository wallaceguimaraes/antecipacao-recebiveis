using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Validations
{
    public sealed class GeneralError: Error
    {
        public GeneralError()
        {
            ErrorMessage = "An unexpected error occurred!";
        }
        
        
    }
}