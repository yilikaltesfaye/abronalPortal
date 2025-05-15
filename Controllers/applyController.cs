using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using abronalPortal.Models;

namespace abronalPortal.Controllers;

public class ApplyController : Controller
{
    private readonly ILogger<ApplyController> _logger;

    public ApplyController(ILogger<ApplyController> logger)
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
