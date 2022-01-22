using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;

namespace api.Models.ViewModels
{
    public sealed class AdvanceRequestModel
    {
        [Display(Name ="transfers")]
        public ICollection<Transfer> Transfers { get; set; }
    }
}