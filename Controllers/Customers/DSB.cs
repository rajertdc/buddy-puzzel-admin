using System.Runtime.CompilerServices;
using AdminPortal.Services.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers.Customers;
[Authorize(Roles = "Customer")]
public class DSB : Controller
{
    public IActionResult Index()
    {
        return View("~/Views/Customer/DSB/Index.cshtml");
    }

    
}