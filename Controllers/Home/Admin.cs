using System.IdentityModel.Tokens.Jwt;
using AdminPortal.Services;
using DotNetEnv;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers;
public class Admin : Controller
{
    [Authorize(Roles = "Administrator")]
    public IActionResult Index()
    {
        try
        {
            return View();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
    
}