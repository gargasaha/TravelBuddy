using Microsoft.AspNetCore.Mvc;
using TravelBuddy.Repository;
using TravelBuddy.DTOs;

namespace TravelBuddy.Controllers
{
    public class HomeController : Controller
    {
        public IAccountRepository accountRepository;
        public HomeController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout() { 
            Response.Cookies.Delete("email");
            return RedirectToAction("Index","Travel");
        }
        [HttpGet("/Home/getUserProfilePic/{email}")]
        public JsonResult getUserProfilePic(string email)
        {
            Console.WriteLine("Got email: " + email);
            byte[] profilePic = null;
            try
            {
                profilePic=accountRepository.getUserProfilePic(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Json(new { profilePictureUrl = profilePic != null ? Convert.ToBase64String(profilePic) : null });

        }
        [HttpGet("/Home/loadCommunities/{email}")]
        public JsonResult loadCommunities(string email)
        {
            List<cIdAndCnameDto> data=accountRepository.getCommunityResult(email);
            return Json(data);   
        }
    }
   
}
