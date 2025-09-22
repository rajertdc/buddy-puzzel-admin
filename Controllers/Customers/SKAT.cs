using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers.Customers;

public class SKAT : Controller
    
{
    [Authorize(Roles = "Customer")]
    public IActionResult Index()
    {
        return View("~/Views/Customer/SKAT/Index.cshtml");
    }
}