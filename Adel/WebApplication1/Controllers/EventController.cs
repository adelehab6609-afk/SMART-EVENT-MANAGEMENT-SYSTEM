using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.App_context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly AppDpcontex _context;

        public EventController()
        {
            _context = new AppDpcontex();
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _context.Events.ToList();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyIdEvent(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev == null)
            {
                return NotFound();
            }
            return Ok(ev);
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] Event ev)
        {
            _context.Events.Add(ev);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetbyIdEvent), new { id = ev.Id }, ev);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, Event ev)
        {
            if (id != ev.Id)
            {
                return BadRequest();
            }

            var existingEvent = _context.Events.Find(id);
            if (existingEvent == null)
            {
                return NotFound();
            }
            existingEvent.Title = ev.Title;
            existingEvent.Description = ev.Description;
            existingEvent.EventDate = ev.EventDate;
            existingEvent.StartTime = ev.StartTime;
            existingEvent.EndTime = ev.EndTime;
            existingEvent.Category = ev.Category;
            existingEvent.Capacity = ev.Capacity;
            existingEvent.VenueId = ev.VenueId;
            existingEvent.OrganizerId = ev.OrganizerId;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchEvent(int id, [FromBody] Event ev)
        {
            var existingEvent = _context.Events.Find(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(ev.Title))
                existingEvent.Title = ev.Title;

            if (!string.IsNullOrEmpty(ev.Description))
                existingEvent.Description = ev.Description;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev == null)
            {
                return NotFound();
            }
            _context.Events.Remove(ev);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
