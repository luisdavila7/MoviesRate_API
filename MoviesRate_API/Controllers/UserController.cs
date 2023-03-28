using Microsoft.AspNetCore.Mvc;

namespace MoviesRate_API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
