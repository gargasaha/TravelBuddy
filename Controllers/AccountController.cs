using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using TravelBuddy.Models;
using TravelBuddy.Repository;
namespace TravelBuddy.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpGet("/Account/CreateUsr")]
        public async Task<IActionResult> CreateUsr()
        {
            return View("CreateUsr");
        }
        [HttpPost("/Account/CreateUsr")]
        public async Task<IActionResult> CreateUsr(Usr usr,IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    usr.uimage = memoryStream.ToArray();
                }
            }
            // Console.WriteLine(usr == null);
            bool res=accountRepository.saveUser(usr);
            if(res)
            {
                Response.Cookies.Delete("email");
                Response.Cookies.Delete("username");
                Response.Cookies.Append("email", usr.email);
                Response.Cookies.Append("username", usr.name);
                ViewData["Message"]="User registered successfully!";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["Message"]="Email already exists";
                // Console.WriteLine("Email already exists");
                return RedirectToAction("CreateUsr");
            }
        }
        [HttpGet("/Account/Login")]
        public IActionResult Login() {
            try {
                if (Request.Cookies["email"] != null) {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex) {
                return View("LoginUsr");
            }
            return View("LoginUsr");
        }
        [HttpPost]
        public IActionResult Login(string email,string password)
        {
            bool res=accountRepository.validateUser(email,password);
            if(res)
            {
                string username=accountRepository.getUserName(email);
                Response.Cookies.Delete("email");
                Response.Cookies.Delete("username");
                Response.Cookies.Append("email", email);
                Response.Cookies.Append("username", username);
                TempData["email"]=email;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Message"]="Invalid email or password";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("email");
            Response.Cookies.Delete("username");
            return RedirectToAction("Index", "Travel");
        }

    }
}