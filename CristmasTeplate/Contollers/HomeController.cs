using Microsoft.AspNetCore.Mvc;

namespace CristmasTeplate.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
