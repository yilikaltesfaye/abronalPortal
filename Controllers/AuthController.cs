using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using abronalPortal.Models;
using Microsoft.AspNetCore.Identity;
using abronalPortal.ViewModels;

namespace abronalPortal.Controllers;

public class AuthController : Controller
{
    private readonly SignInManager<Users> signInManager;
    private readonly UserManager<Users> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public AuthController(SignInManager<Users> signInManager, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.roleManager = roleManager;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        if(result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }
        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
    }


}
