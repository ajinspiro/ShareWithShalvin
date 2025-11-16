using System.Threading.Tasks;
using AuthedContoso.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthedContoso.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(
         string username, string password,
         [FromServices] SignInManager<ApplicationUser> signInManager
        )
    {
        await signInManager.PasswordSignInAsync(username, password, false, false);
        return Redirect("/Home/Privacy");
    }

    [HttpPost]
    public async Task<IActionResult> LoginB(
         string username, string password,
         [FromServices] SignInManager<ApplicationUser> signInManager
        )
    {
        signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
        await signInManager.PasswordSignInAsync(username, password, false, false);
        return new EmptyResult();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(
        string username, string password, string fullname,
        [FromServices] UserManager<ApplicationUser> userManager
        )
    {
        ApplicationUser newUser = new()
        {
            UserName = username,
            FullName = fullname
        };
        await userManager.CreateAsync(newUser);
        await userManager.AddPasswordAsync(newUser, password);
        return Redirect("/Account/Login");
    }
}
