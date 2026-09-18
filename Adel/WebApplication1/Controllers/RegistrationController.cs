using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.App_context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly AppDpcontex _context;

        public RegistrationController()
        {
            _context = new AppDpcontex();
        }

        [HttpPost]
        public IActionResult RegisterAttendee([FromBody] Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
            return Created();
        }

        [HttpGet]
        public IActionResult GetRegistrations()
        {
            var registrations = _context.Registrations.ToList();
            return Ok(registrations);
        }

        [HttpPatch ("{id}")]
        public IActionResult UpdateRegistration(int id, Registration registration)
        {
            var existingRegistration = _context.Registrations.Find(id);
            if (existingRegistration == null)
            {
                return NotFound();
            }
            existingRegistration.Status = registration.Status;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
