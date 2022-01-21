using System.ComponentModel.DataAnnotations;
using api.Models.EntityModel;
using api.Models.Validations;

namespace api.Models.ViewModels
{
    public sealed class PaymentModel
    {
        
        [Display(Name ="creditCard")]
        [StringLength(16, ErrorMessage ="O cartão de crédito deve possuir 16 dígitos!", MinimumLength =16)]
        public string CreditCard { get; set; }

        [Display(Name ="valueTotal"), AmountRequired]
        [Required]
        public decimal ValueTotal { get; set; }

        [Display(Name ="installmentsAmount"), AmountRequired]
        [Required]
        public int InstallmentsAmount { get; set; }

    }
}