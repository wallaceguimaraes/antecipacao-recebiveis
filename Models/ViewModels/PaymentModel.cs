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

        [Display(Name ="installments"), AmountRequired]
        [Required]
        public decimal Installments { get; set; }


        /*     public Model MapTo(Model model)
            {
                model.BrandId = BrandId.Value;
                model.Name = Name;

                return model;
            } */
    }
}