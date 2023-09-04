using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models
{
    public class EventsParticipantsModel
    {
        [Key]
        public int Id { get; set; }
        public EventsModel Event { get; set; }
        public int EventId { get; set; }
        public UserModel User { get; set; }
        public string UserId { get; set; }
    }
}
