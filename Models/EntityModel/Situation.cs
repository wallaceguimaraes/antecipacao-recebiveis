namespace api.Models.EntityModel
{
    public class Situation
    {
        public Situation(int situationId, string description)
        {
            this.SituationId = situationId;
            this.Description = description;
        }

        public int SituationId { get; set; }
        public string Description { get; set; }
    }
}