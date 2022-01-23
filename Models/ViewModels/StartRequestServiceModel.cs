using api.Models.EntityModel;
using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModels
{
    public sealed class StartRequestServiceModel
    {
        [Display(Name ="advanceRequest")]
        [Required]
        public AdvanceRequest AdvanceRequest { get; set; }
    }
}