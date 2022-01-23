
namespace api.Models.Validations
{
    public sealed class InvalidCard : CreditCardError
    {
        public InvalidCard()
        {
            ErrorMessage = "Invalid credit card!";
        }
        
    }
}