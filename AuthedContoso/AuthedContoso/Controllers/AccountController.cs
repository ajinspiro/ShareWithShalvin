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
    public IActionResult Login(
        [FromQuery] string username, [FromQuery] string password
        )
    {
        return Ok("super cool");
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
