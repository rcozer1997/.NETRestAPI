using System.ComponentModel.DataAnnotations;

namespace RestAPI.DTO.Events
{
    public class EventsUpdateDTO
    {
        [Required]
        [MinLength(8)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
