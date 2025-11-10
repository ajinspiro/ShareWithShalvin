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
}
