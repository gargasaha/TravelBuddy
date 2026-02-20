using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelBuddy.Models;

namespace TravelBuddy.Controllers;

public class TravelController : Controller
{
    private readonly ILogger<TravelController> _logger;
    private readonly IConfiguration _configuration;

    public TravelController(ILogger<TravelController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public IActionResult Index()
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
