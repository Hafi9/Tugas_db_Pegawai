
using System.Data.SqlClient;

namespace MCCArchitecture;



public class Connection
{
    private static string _connectionString =
        "Data Source = DESKTOP-MEQ0V63\\MSSQLSERVER01;" +
        "Initial Catalog = db_pegawai;" +
        "Integrated Security = true;";

    private static SqlConnection _connection;

    public static SqlConnection Get()
    {
        try
        {
            _connection = new SqlConnection(_connectionString);
            return _connection;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
