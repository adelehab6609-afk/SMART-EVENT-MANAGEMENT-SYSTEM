using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.App_context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly AppDpcontex _context;

        public OrganizerController()
        {
            _context = new AppDpcontex();
        }

        [HttpGet]
        public IActionResult GetOrganizers()
        {
            var organizers = _context.Organizers.ToList();
            return Ok(organizers);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrganizerById(int id)
        {
            var organizer = _context.Organizers.Find(id);
            if (organizer == null)
            {
                return NotFound();
            }
            return Ok(organizer);
        }


        [HttpPost]
        public IActionResult CreateOrganizer([FromBody] Organizer organizer)
        {
            _context.Organizers.Add(organizer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOrganizerById), new { id = organizer.Id }, organizer);
        }
    }
}
