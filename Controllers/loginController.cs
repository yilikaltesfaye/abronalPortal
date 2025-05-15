using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using abronalPortal.Models;
using Microsoft.AspNetCore.Identity;

namespace abronalPortal.Controllers;

public class loginController : Controller
{
    private readonly SignInManager<Users> signInManager;
    private readonly UserManager<Users> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public loginController(SignInManager<Users> signInManager, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.roleManager = roleManager;
    }
    [HttpGet]
    public IActionResult index()
    {
        return View();
    }

}
