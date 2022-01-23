using System.ComponentModel.DataAnnotations;

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
