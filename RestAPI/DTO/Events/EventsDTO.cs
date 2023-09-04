using System.ComponentModel.DataAnnotations;

namespace RestAPI.DTO.Events
{
    public class EventsDTO
    {
        [Required]
        [MinLength(8)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string ResponsibleEmail { get; set; }

        [Required]
        public List<string> ParticipantsEmails { get; set; }
       
    }
}
