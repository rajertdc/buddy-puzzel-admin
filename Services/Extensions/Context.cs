
using Microsoft.Data.SqlClient;

namespace AdminPortal.Services.Extensions;

public class Context
{
    public Context()
    {
        string connectionString = EnvService.GetConnectionString();
        try
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var sql = "SELECT * FROM Customers";
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}