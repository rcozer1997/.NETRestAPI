namespace RestAPI.Models
{
    public class EventsModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } 
        public DateTime? Date { get; set; }
        public int? ResponsibleId { get; set; }
        public virtual UserModel? Responsible { get; set; }
        public List<int>? ParticipantsId { get; set; }
        public virtual List<UserModel>? Participants { get; set; }

    }
}
