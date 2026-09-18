using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(200)]
        public string Location { get; set; }
        [Required, Range(1, 10000, ErrorMessage = "Capacity must be a positive number.")]
        public int Capacity { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}

//Id
//Name
//Location
//Capacity