using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AdminPortal.Services;

public class JWTService
{
    public static ClaimsPrincipal? Authenticate(string token)
    {
        string secretKey = EnvService.GetSecretKey();
        string issuer = EnvService.GetIssuer();
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        string[] audience = EnvService.GetAudiences();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudiences = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

        };
        try
        {
            var principal = handler.ValidateToken(token, validationParameters, out SecurityToken securityToken);
            return principal;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

}