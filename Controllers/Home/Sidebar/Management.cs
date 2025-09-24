using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace AdminPortal.Controllers.Sidebar;

public class Management : Controller
{
    
    public IActionResult Customers()
    {
        Console.WriteLine($"Users domain: {User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)}");
        return View("~/Views/Home/Sidebar/Customers.cshtml");
    }

    public IActionResult Administrators()
    {
        return View();
    }

    public IActionResult Account()
    {
        return View();
    }

    public IActionResult OrganizationSettings()
    {
        return View();
    }

    public IActionResult Resources()
    {
        return View();
    }
}