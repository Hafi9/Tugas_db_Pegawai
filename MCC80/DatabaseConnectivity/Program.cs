using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DatabaseConnectivity;

public class Program
{
    private static string _connectionString =
        "Data Source = DESKTOP-MEQ0V63\\MSSQLSERVER01;" +
        "Initial Catalog = db_pegawai;" +
        "Integrated Security = true;";

    private static SqlConnection _connection;

    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Utama:");
            Console.WriteLine("1. Employees");
            Console.WriteLine("2. Departments");
            Console.WriteLine("3. Histories");
            Console.WriteLine("4. Jobs");
            Console.WriteLine("5. Locations");
            Console.WriteLine("6. Countries");
            Console.WriteLine("7. Regions");
            Console.WriteLine("8. Exit");

            Console.Write("Pilih menu (1-8): ");
            string input = Console.ReadLine();

            if (input == "1")
            {
               //employees
            }
            else if (input == "2")
            {
                //departments
            }
            else if (input == "3")
            {
                //histories
            }
            else if (input == "4")
            {
                //Jobs
            }
            else if (input == "5")
            {
                //locations
            }
            else if (input == "6")
            {
                Console.Clear();
                CountriesMenu();
            }
            else if (input == "7")
            {
                Console.Clear();
                RegionMenu();
            }
            else if (input == "8")
            {
                break;
            }
            else
            {
                Console.WriteLine("Input tidak valid. Silakan coba lagi.");
                Console.WriteLine();
            }
        }
    }

    public static void CountriesMenu()
    {
        while (true)
        {
            Console.WriteLine("Menu Countries:");
            Console.WriteLine("1. Tampilkan Countries");
            Console.WriteLine("2. Create Countries");
            Console.WriteLine("3. Update Countries");
            Console.WriteLine("4. Delete Countries");
            Console.WriteLine("5. Kembali ke Menu Utama");

            Console.Write("Pilih menu (1-4): ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                GetCountries();
            }
            else if (input == "2")
            {
                //Console.Write("Masukkan nama country yang akan dibuat: ");
                //string name = Console.ReadLine();
                //InsertCountry(name);
            }
            else if (input == "3")
            {
                Console.Clear();
                Console.Write("Masukkan ID country yang akan diupdate: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Masukkan nama region baru: ");
                string name = Console.ReadLine();
                UpdateRegions(name, id);
            }
            else if (input == "4")
            {
                Console.Clear();
                Console.Write("Masukkan ID counrty yang akan dihapus: ");
                int id = int.Parse(Console.ReadLine());
                DeleteRegions(id);
            }
            else if (input == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Input tidak valid. Silakan coba lagi.");
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }

    public static void RegionMenu()
    {
        while (true)
        {
            Console.WriteLine("Menu Region:");
            Console.WriteLine("1. Tampilkan Region");
            Console.WriteLine("2. Create Region");
            Console.WriteLine("3. Update Region");
            Console.WriteLine("4. Delete Region");
            Console.WriteLine("5. Get ID Region");
            Console.WriteLine("6. Kembali ke Menu Utama");

            Console.Write("Pilih menu (1-5): ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                GetRegions();
            }
            else if (input == "2")
            {
                Console.Write("Masukkan nama region yang akan dibuat: ");
                string name = Console.ReadLine();
                InsertRegions(name);
            }
            else if (input == "3")
            {
                Console.Write("Masukkan ID region yang akan diupdate: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Masukkan nama region baru: ");
                string name = Console.ReadLine();
                UpdateRegions(name, id);
            }
            else if (input == "4")
            {
                Console.Write("Masukkan ID region yang akan dihapus: ");
                int id = int.Parse(Console.ReadLine());
                DeleteRegions(id);
            }
            else if (input == "5")
            {
                Console.Write("Masukkan ID region: ");
                int id = int.Parse(Console.ReadLine());
                GetRegionById(id);
            }
            else if (input == "6")
            {
                break;
            }
            else
            {
                Console.WriteLine("Input tidak valid. Silakan coba lagi.");
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }

    //Get all data
    public static void GetRegions()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM regions";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(i: 0));
                    Console.WriteLine("Name: " + reader.GetString(i: 1));
                }

            }
            else
            {
                Console.WriteLine("No Regions Found");
            }
            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connection to Database");
        }


    }
    public static void GetCountries()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM countries";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader.GetString(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("ID Region: " + reader.GetInt32(2));
                }

            }
            else
            {
                Console.WriteLine("No Country Found");
            }
            reader.Close();
            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
            Console.WriteLine("Stack Trace: " + ex.StackTrace);
        }


    }

    //INSERT
    public static void InsertCountry(string name)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO Regions values (@name)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Fail");
            }
            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connection to Database");
        }


    }
    public static void InsertRegions(string name)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO Regions values (@name)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Fail");
            }
            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connection to Database");
        }


    }

    // UPDATE
    public static void UpdateCounrty(string name, string country_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE countries SET name = @name WHERE country_id = @country_id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pCounrtyId = new SqlParameter();
            pCounrtyId.ParameterName = "@country_id";
            pCounrtyId.SqlDbType = System.Data.SqlDbType.Int;
            pCounrtyId.Value = country_id;
            sqlCommand.Parameters.Add(pCounrtyId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success");
            }
            else
            {
                Console.WriteLine("Update Fail");
            }
            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to the database");
        }
    }

    public static void UpdateRegions(string name, int region_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE regions SET name = @name WHERE region_id = @region_id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.SqlDbType = System.Data.SqlDbType.Int;
            pRegionId.Value = region_id;
            sqlCommand.Parameters.Add(pRegionId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success");
            }
            else
            {
                Console.WriteLine("Update Fail");
            }
            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to the database");
        }
    }

    //DELETE
    public static void DeleteCountries(string country_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM countries WHERE country_id = @country_id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@country_id";
            pCountryId.SqlDbType = System.Data.SqlDbType.Int;
            pCountryId.Value = country_id;
            sqlCommand.Parameters.Add(pCountryId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success");
            }
            else
            {
                Console.WriteLine("Delete Fail");
            }
            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to the database");
        }
    }

    public static void DeleteRegions(int region_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM regions WHERE region_id = @region_id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.SqlDbType = System.Data.SqlDbType.Int;
            pRegionId.Value = region_id;
            sqlCommand.Parameters.Add(pRegionId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success");
            }
            else
            {
                Console.WriteLine("Delete Fail");
            }
            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to the database");
        }
    }

    //Get by ID Regions
    public static void GetCountryById(string country_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM countries WHERE country_id = @country_id";
        sqlCommand.Parameters.AddWithValue("@country_id", country_id);

        try
        {
            _connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetString(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("ID Region: " + reader.GetInt32(2));
                }
            }
            else
            {
                Console.WriteLine("No Region Found");
            }
            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to the database");
        }

    }

    public static void GetRegionById(int region_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM regions WHERE region_id = @region_id";
        sqlCommand.Parameters.AddWithValue("@region_id", region_id);

        try
        {
            _connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No Region Found");
            }
            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to the database");
        }

    }
}

