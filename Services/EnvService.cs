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
    
    public static string GetConnectionString()
    {
        Env.Load();
        string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        return connectionString;
    }
}
