using AdminPortal.Models;

namespace AdminPortal.Services;
using DotNetEnv;

public class EnvService
{
    public static string GetSecretKey()
    {
        Env.Load();
        string secretKey = Environment.GetEnvironmentVariable("SECRET_KEY");
        return secretKey;
    }

    public static string GetIssuer()
    {
        Env.Load();
        string issuer = Environment.GetEnvironmentVariable("ISSUER");
        return issuer;
    }

    public static string[] GetAudiences()
    {
        Env.Load();
        string audience = Environment.GetEnvironmentVariable("AUDIENCES");
        string[] audiences = audience.Split(',');
        return audiences;
    }

    internal class API
    {
        public static string GetToken()
        {
            Env.Load();
            string token = Environment.GetEnvironmentVariable("TOKEN");
            return token;
        }
        
        public static string GetBaseUrl()
        {
            Env.Load();
            string baseUrl = Environment.GetEnvironmentVariable("BASE_URL");
            return baseUrl;
        }
        
    }
    
}
