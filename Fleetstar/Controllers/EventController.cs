using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fleetstar.Components
{
    [Authorize]
    [ApiController]
    [Route("api/events")]
    public class EventController : Controller
    {
        private readonly EventRepository _eventRepository;
        private readonly BookingRepository bookingRepository;

        public EventController(EventRepository eventRepository, BookingRepository bookingRepository)
        {
            _eventRepository = eventRepository;
            this.bookingRepository = bookingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _eventRepository.GetEvents();
            return Ok(events);
        }

        [HttpGet]
        [Route("api/bookings/getall")]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await bookingRepository.GetBookingsAsync();
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event eventToAdd)
        {
            if (eventToAdd == null)
            {
                return BadRequest();
            }

            var addedEvent = await _eventRepository.AddEvent(eventToAdd);
            return CreatedAtAction(nameof(GetEvents), new { id = addedEvent.Id }, addedEvent);
        }
    }
}