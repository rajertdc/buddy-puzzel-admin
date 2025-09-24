using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers.Sidebar;

public class Service : Controller
{
    public IActionResult Services()
    {
        return View();
    }
}