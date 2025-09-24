using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Services.Extensions;

public static class ControllerExtensions
{
    public static async Task<IActionResult> SignOutUser(this Controller controller)
    {
        await controller.HttpContext.SignOutAsync();
        controller.Response.Cookies.Delete("AuthToken");
        Console.WriteLine($"User has been logged out. Redirecting to Login page");
        return controller.RedirectToAction("Login", "Home");
    }
}