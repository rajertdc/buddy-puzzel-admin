using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers;

public class Monitoring : Controller
{
    public IActionResult Reports()
    {
        return View();
    }

    public IActionResult Analysis()
    {
        return View();
    }
}