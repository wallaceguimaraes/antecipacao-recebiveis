using api.Models.EntityModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace api.Models.ViewModels
{
    public sealed class ApproveOrDisapproveModel
    {

        [Display(Name = "status")]
        [Required]
        public string Status { get; set; }

        [Display(Name = "advanceRequestId")]
        [Required]
        public int AdvanceRequestId { get; set; }

        [Display(Name = "transfers")]
        [Required]
        public ICollection<Transfer> Transfers { get; set; }


    }
}