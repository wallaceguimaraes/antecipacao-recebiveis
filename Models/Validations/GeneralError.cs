
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