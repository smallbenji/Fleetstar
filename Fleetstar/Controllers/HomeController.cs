using System.Threading.Tasks;
using Fleetstar.Components;
using Microsoft.AspNetCore.Mvc;

namespace Fleetstar.Controllers
{
    public class HomeController : Controller
    {
        readonly EventRepository eventRepository;

        public HomeController(EventRepository eventRepository) {
            this.eventRepository = eventRepository;
        }

        public async Task<IActionResult> Index()
        {
            var events = await eventRepository.GetEvents();
            return View(events);
        }
    }
}
