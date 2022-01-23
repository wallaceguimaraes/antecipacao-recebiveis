using api.Models.EntityModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModels
{
    public sealed class AdvanceRequestModel
    {
        [Display(Name ="transfers")]
        [Required]
        public ICollection<Transfer> Transfers { get; set; }
    }
}