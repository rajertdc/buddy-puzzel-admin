using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers.Sidebar;

public class Management : Controller
{
    public IActionResult Customers()
    {
        return View();
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