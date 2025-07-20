using Microsoft.AspNetCore.Mvc;

namespace Fleetstar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
