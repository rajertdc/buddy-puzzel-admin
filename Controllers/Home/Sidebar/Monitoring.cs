using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers.Sidebar;

public class Monitoring : Controller
{
    public IActionResult Analytics()
    {
        return View();
    }public IActionResult Reports()
    {
        return View();
    }
}