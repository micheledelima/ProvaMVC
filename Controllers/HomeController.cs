using Microsoft.AspNetCore.Mvc;

namespace ProvaMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
