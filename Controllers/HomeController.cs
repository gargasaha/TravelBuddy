using Microsoft.AspNetCore.Mvc;

namespace TravelBuddy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout() { 
            Response.Cookies.Delete("email");
            return RedirectToAction("Index","Travel");
        }
    }
   
}
