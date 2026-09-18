using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.App_context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly AppDpcontex _context;

        public VenueController()
        {
            _context = new AppDpcontex();
        }

        [HttpGet]
        public IActionResult GetVenues()
        {
            var venues = _context.Venues.ToList();
            return Ok(venues);
        }

        [HttpGet("{id}")]
        public IActionResult GetVenueById(int id)
        {
            var venue = _context.Venues.Find(id);
            if (venue == null)
            {
                return NotFound();
            }
            return Ok(venue);
        }
        
        [HttpPost]
        public IActionResult CreateVenue([FromBody] Venue venue)
        {
            _context.Venues.Add(venue);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVenueById), new { id = venue.Id }, venue);
        }
    }
}
