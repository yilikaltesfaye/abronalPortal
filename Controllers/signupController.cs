using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using abronalPortal.Models;

namespace abronalPortal.Controllers;

public class signupController : Controller
{
    private readonly ILogger<signupController> _logger;

    public signupController(ILogger<signupController> logger)
    {
        _logger = logger;
    }

    public IActionResult index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
