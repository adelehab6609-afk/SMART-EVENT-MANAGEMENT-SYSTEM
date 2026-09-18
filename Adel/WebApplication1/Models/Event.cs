using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required, MaxLength(50)]
        public string Category { get; set; }
        [Required, Range(1, 10000, ErrorMessage = "Capacity must be a positive number.")]
        public int Capacity { get; set; }
        [ForeignKey(nameof(Venue))]
        public int VenueId { get; set; }
        [ForeignKey(nameof(Organizer))]
        public int OrganizerId { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual Organizer Organizer { get; set; }
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}