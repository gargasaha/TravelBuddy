using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelBuddy.Models;
using TravelBuddy.Repository;

namespace TravelBuddy.Controllers;

public class TravelController : Controller
{
    private readonly ILogger<TravelController> _logger;
    private readonly IConfiguration _configuration;
    private TravelRepository travelDAL;
    public TravelController(ILogger<TravelController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        travelDAL=new TravelRepository(_configuration);
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
        var i=await travelDAL.registerCommunity(community,ImageFile);
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
        return RedirectToAction("Index");
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
