using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.UI.Controllers
{
    public class PlatiniumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
