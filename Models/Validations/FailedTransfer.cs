
namespace api.Models.Validations
{
    public sealed class FailedTransfer : FailedTransaction
    {
        public FailedTransfer()
        {
            Message = "The transaction has been disapproved!";
        }
        
        
    }
}