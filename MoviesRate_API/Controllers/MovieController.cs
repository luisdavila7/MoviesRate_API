using Microsoft.AspNetCore.Mvc;

namespace MoviesRate_API.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
