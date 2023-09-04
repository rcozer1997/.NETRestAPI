using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models
{
    public class EventsModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } 
        public DateTime Date { get; set; }
        public string? ResponsibleId { get; set; }
        public virtual UserModel? Responsible { get; set; }          
        public virtual List<EventsParticipantsModel>? Participants { get; set; }
    }
}
