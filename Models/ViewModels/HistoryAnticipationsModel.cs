using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.ViewModels
{
    public class HistoryAnticipationsModel
    {
        [Display(Name = "situationId")]
        [Required]
        public int SituationId { get; set; }

    }
}