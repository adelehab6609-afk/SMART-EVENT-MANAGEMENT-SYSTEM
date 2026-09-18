using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;   

namespace WebApplication1.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required, StringLength(30)]
        public string Status { get; set; }

        [Required, ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        [Required, ForeignKey(nameof(Attendee))]
        public int AttendeeId { get; set; }
        public Event Event { get; set; }
        public Attendee Attendee { get; set; }
    }
}
//RegistrationId
//RegistrationDate
//Status
//EventId
//AttendeeId