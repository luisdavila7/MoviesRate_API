using Microsoft.AspNetCore.Mvc;

namespace MoviesRate_API.Controllers
{
    public class RateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
