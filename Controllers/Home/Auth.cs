using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AdminPortal.Services;
using AdminPortal.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using DotNetEnv;

namespace AdminPortal.Controllers;

public class Auth : Controller
{
    private readonly IConfiguration _configuration;

    public Auth(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult Authenticate(string email, string password)
    {
        HashAlgorithm sha = SHA256.Create();
        sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        string[] emailArray = email.Split("@");
        string domain = emailArray[1];
        Console.WriteLine($"Current domain: {domain}");

        switch (domain)
        {
            case "tdc.dk":
                var adminToken = GenerateJwtToken("tdc.dk");
                var principal = JWTService.Authenticate(adminToken);

                Response.Cookies.Append("AuthToken", adminToken, new CookieOptions { HttpOnly = true, Secure = true });
                return RedirectToAction("Overview", "Admin");


            default:
                return RedirectToAction("NotAuthorized", "Home");
        }
    }

    private string GenerateJwtToken(string domain)
    {
        //Checking which domain is trying to access the page.
        //Giving user access to certain parts of application depending on domain
        string tokenType = "";
        if (domain.ToLower() == "tdc.dk")
        {
            tokenType = "Administrator";
        }
        else if (!domain.ToLower().IsNullOrEmpty())
        {
            tokenType = "Customer";
        }

        //Creating claims array
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, domain),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, tokenType),
        };
        Console.WriteLine($"Current User's access: {tokenType}");


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EnvService.GetSecretKey()));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "tdc.dk",
            audience: domain,
            claims: claims,
            expires: DateTime.Now.AddHours(4),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public Task<IActionResult> SignOut()
    {
        return this.SignOutUser();
    }
}