using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelBuddy.Models;
using TravelBuddy.Repository;

namespace TravelBuddy.Controllers;

public class TravelController : Controller
{
    private ITravelRepository travelRepository;
    public TravelController(ITravelRepository travelRepository)
    {
        this.travelRepository = travelRepository;
    }
    [HttpGet("/Travel/CreateCommunity")]
    public IActionResult CreateCommunity()
    {
        ViewData["Message"] = null;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCommunity(Community community,IFormFile ImageFile)
    {
        // Console.WriteLine("Received community data: " + community.cname + ", " + community.cemail+ ", ImageFile: " + (ImageFile != null ? ImageFile.FileName : "No file")+community.cpassword);
        var i=await travelRepository.registerCommunity(community,ImageFile);
        if (i == -1)
        {
            ViewData["Message"]="Email already exists. Please use a different email.";
            return View();
        }
        else if(i == 1)
        {
            ViewData["Message"]="Community created successfully!";
            return View();
        }
        return RedirectToAction("Index","Home");
    }
    [HttpGet("/Travel/CommunityDetails/{cid}")]
    public IActionResult CommunityDetails(int cid)
    {
        Response.Cookies.Append("cid", cid.ToString());
        ViewData["Message"] = null;
        return View();
    }
    
    public IActionResult Index()
    {
        var username=Request.Cookies["username"];
        if (username != null)
        {
            TempData["username"]=username;
        }
        else
        {
            TempData["username"]=null;
        }
        return View();
    }
    [HttpPost("Travel/SendMessage")]
    public JsonResult SendMessage(string message)
    {
        Console.WriteLine("Message: {0}, Email: {1}, CID: {2}", message, Request.Cookies["email"], Request.Cookies["cid"]);
        bool response=travelRepository.sendMessage(message,Request.Cookies["email"],Convert.ToInt32(Request.Cookies["cid"]));
        Console.WriteLine(response);
        return Json(new { success = true });
    }

    [HttpGet("/Travel/CreateRide")]
    public IActionResult CreateRide()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
