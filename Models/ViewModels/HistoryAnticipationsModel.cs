using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModels
{
    public class HistoryAnticipationsModel
    {
        [Display(Name = "situationId")]
        [Required]
        public int SituationId { get; set; }

    }
}