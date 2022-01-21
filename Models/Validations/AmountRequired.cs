using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Validations
{
    public sealed class AmountRequired : RequiredAttribute
    {
        public AmountRequired()
        {
            ErrorMessage = "Required field!";

        }
    }
}
