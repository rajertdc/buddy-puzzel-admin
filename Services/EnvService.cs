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
        string audience = Environment.GetEnvironmentVariable("AUDIENCE");
        string[] audiences = audience.Split(',');
        return audiences;
    }
}
