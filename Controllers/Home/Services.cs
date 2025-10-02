using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers;

public class Services : Controller
{
    public IActionResult Licenses()
    {
        return View();
    }
}