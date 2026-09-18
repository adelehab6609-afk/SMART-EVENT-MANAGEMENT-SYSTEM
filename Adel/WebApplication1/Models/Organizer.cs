using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Organizer
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}

//Id
//FullName
//Email
//Phone