using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Attendee
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }    
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
//Id
//FullName
//Email
//Phone