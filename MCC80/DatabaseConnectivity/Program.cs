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
                Console.Clear();
                DepartmentMenu();
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
                Console.Clear();
                LocationMenu();
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
    public static void HistoriesMenu()
    {
        while (true)
        {
            Console.WriteLine("Menu Histories:");
            Console.WriteLine("1. Tampilkan Semua Histories");
            Console.WriteLine("2. Tampilkan History berdasarkan Employee ID");
            Console.WriteLine("3. Create History");
            Console.WriteLine("4. Update History");
            Console.WriteLine("5. Delete History");
            Console.WriteLine("6. Kembali ke Menu Utama");

            Console.Write("Pilih menu (1-6): ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                GetHistories();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.Write("Masukkan Employee ID: ");
                int employeeId = int.Parse(Console.ReadLine());
                GetHistoryByEmployeeId(employeeId);
            }
            else if (input == "3")
            {
                Console.Clear();
                Console.Write("Masukkan Start Date (yyyy-mm-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Masukkan Employee ID: ");
                int employeeId = int.Parse(Console.ReadLine());
                Console.Write("Masukkan End Date (yyyy-mm-dd): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Masukkan Department ID: ");
                int departmentId = int.Parse(Console.ReadLine());
                Console.Write("Masukkan Job ID: ");
                string jobId = Console.ReadLine();
                InsertHistory(startDate, employeeId, endDate, departmentId, jobId);
            }
            else if (input == "4")
            {
                Console.Clear();
                Console.Write("Masukkan Employee ID History yang akan diupdate: ");
                int employeeId = int.Parse(Console.ReadLine());
                Console.Write("Masukkan Start Date baru (yyyy-mm-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Masukkan Employee ID baru: ");
                int newEmployeeId = int.Parse(Console.ReadLine());
                Console.Write("Masukkan End Date baru (yyyy-mm-dd): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Masukkan Department ID baru: ");
                int departmentId = int.Parse(Console.ReadLine());
                Console.Write("Masukkan Job ID baru: ");
                string jobId = Console.ReadLine();
                UpdateHistory(employeeId, startDate, newEmployeeId, endDate, departmentId, jobId);
            }
            else if (input == "5")
            {
                Console.Clear();
                Console.Write("Masukkan Employee ID History yang akan dihapus: ");
                int employeeId = int.Parse(Console.ReadLine());
                DeleteHistory(employeeId);
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
    public static void DepartmentMenu()
    {
        while (true)
        {
            Console.WriteLine("Menu Departments:");
            Console.WriteLine("1. Tampilkan Departments");
            Console.WriteLine("2. Tambah Department");
            Console.WriteLine("3. Update Department");
            Console.WriteLine("4. Hapus Department");
            Console.WriteLine("5. Cari Department berdasarkan ID");
            Console.WriteLine("6. Kembali ke Menu Utama");

            Console.Write("Pilih menu (1-6): ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                GetDepartments();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.Write("Masukkan nama Department: ");
                string name = Console.ReadLine();
                Console.Write("Masukkan ID Location: ");
                int locationId = int.Parse(Console.ReadLine());
                Console.Write("Masukkan ID Manager: ");
                int managerId = int.Parse(Console.ReadLine());
                InsertDepartment(name, locationId, managerId);
            }
            else if (input == "3")
            {
                Console.Clear();
                Console.Write("Masukkan ID Department yang akan diupdate: ");
                int departmentId = int.Parse(Console.ReadLine());
                Console.Write("Masukkan nama Department baru: ");
                string name = Console.ReadLine();
                Console.Write("Masukkan ID Location baru: ");
                int locationId = int.Parse(Console.ReadLine());
                Console.Write("Masukkan ID Manager baru: ");
                int managerId = int.Parse(Console.ReadLine());
                UpdateDepartment(departmentId, name, locationId, managerId);
            }
            else if (input == "4")
            {
                Console.Clear();
                Console.Write("Masukkan ID Department yang akan dihapus: ");
                int departmentId = int.Parse(Console.ReadLine());
                DeleteDepartment(departmentId);
            }
            else if (input == "5")
            {
                Console.Clear();
                Console.Write("Masukkan ID Department yang ingin dicari: ");
                int departmentId = int.Parse(Console.ReadLine());
                GetDepartmentById(departmentId);
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

    public static void LocationMenu()
    {
        while (true)
        {
            Console.WriteLine("Menu Location:");
            Console.WriteLine("1. Tampilkan Location");
            Console.WriteLine("2. Create Location");
            Console.WriteLine("3. Update Location");
            Console.WriteLine("4. Delete Location");
            Console.WriteLine("5. Cari Location berdasarkan ID");
            Console.WriteLine("6. Kembali ke Menu Utama");

            Console.Write("Pilih menu (1-6): ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                GetLocations();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.Write("Masukkan Street Address: ");
                string streetAddress = Console.ReadLine();
                Console.Write("Masukkan Postal Code: ");
                string postalCode = Console.ReadLine();
                Console.Write("Masukkan City: ");
                string city = Console.ReadLine();
                Console.Write("Masukkan State Province: ");
                string stateProvince = Console.ReadLine();
                Console.Write("Masukkan Country ID: ");
                int countryId = int.Parse(Console.ReadLine());
                InsertLocation(streetAddress, postalCode, city, stateProvince, countryId);
            }
            else if (input == "3")
            {
                Console.Clear();
                Console.Write("Masukkan ID location yang akan diupdate: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Masukkan Street Address baru: ");
                string streetAddress = Console.ReadLine();
                Console.Write("Masukkan Postal Code baru: ");
                string postalCode = Console.ReadLine();
                Console.Write("Masukkan City baru: ");
                string city = Console.ReadLine();
                Console.Write("Masukkan State Province baru: ");
                string stateProvince = Console.ReadLine();
                Console.Write("Masukkan Country ID baru: ");
                int countryId = int.Parse(Console.ReadLine());
                UpdateLocation(id, streetAddress, postalCode, city, stateProvince, countryId);
            }
            else if (input == "4")
            {
                Console.Clear();
                Console.Write("Masukkan ID location yang akan dihapus: ");
                int id = int.Parse(Console.ReadLine());
                DeleteLocation(id);
            }
            else if (input == "5")
            {
                Console.Clear();
                Console.Write("Masukkan ID Location yang ingin dicari: ");
                int locationId = int.Parse(Console.ReadLine());
                GetLocationById(locationId);
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


    public static void CountriesMenu()
    {
        while (true)
        {
            Console.WriteLine("Menu Countries:");
            Console.WriteLine("1. Tampilkan Countries");
            Console.WriteLine("2. Create Countries");
            Console.WriteLine("3. Update Countries");
            Console.WriteLine("4. Delete Countries");
            Console.WriteLine("5. Cari Countries berdasarkan ID");
            Console.WriteLine("6. Kembali ke Menu Utama");

            Console.Write("Pilih menu (1-6): ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                GetCountries();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.Write("Masukkan ID country yang akan dibuat: ");
                Console.Write("Masukkan nama country yang akan dibuat: ");
                string name = Console.ReadLine();
                string country_id = Console.ReadLine();
                InsertCountry(name, country_id);
            }
            else if (input == "3")
            {
                Console.Clear();
                Console.Write("Masukkan ID country yang akan diupdate: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Masukkan nama region baru: ");
                string name = Console.ReadLine();
                string country_id = string.Empty;
                UpdateCounrty(name, country_id);
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
                Console.Clear();
                Console.Write("Masukkan ID Country yang ingin dicari: ");
                int country_id = int.Parse(Console.ReadLine());
                GetCountryById(country_id);
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
                Console.Clear();
                GetRegions();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.Write("Masukkan nama region yang akan dibuat: ");
                string name = Console.ReadLine();
                InsertRegions(name);
            }
            else if (input == "3")
            {
                Console.Clear();
                Console.Write("Masukkan ID region yang akan diupdate: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Masukkan nama region baru: ");
                string name = Console.ReadLine();
                UpdateRegions(name, id);
            }
            else if (input == "4")
            {
                Console.Clear();
                Console.Write("Masukkan ID region yang akan dihapus: ");
                int id = int.Parse(Console.ReadLine());
                DeleteRegions(id);
            }
            else if (input == "5")
            {
                Console.Clear();
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
    public static void GetHistories()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Histories";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("History ID: " + reader.GetInt32(0));
                    Console.WriteLine("Start Date: " + reader.GetDateTime(1).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Employee ID: " + reader.GetInt32(2));
                    Console.WriteLine("End Date: " + reader.GetDateTime(3).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Department ID: " + reader.GetInt32(4));
                    Console.WriteLine("Job ID: " + reader.GetString(5));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Histories Found");
            }

            reader.Close();
            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void GetDepartments()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Departments";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int locationId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                    int managerId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                    Console.WriteLine("Department ID: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("Location ID: " + locationId);
                    Console.WriteLine("Manager ID: " + managerId);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Departments Found");
            }

            reader.Close();
            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }

    public static void GetLocations()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Locations";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string streetAddress = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                    string postalCode = reader.IsDBNull(2) ? "N/A" : reader.GetString(2);
                    string city = reader.IsDBNull(3) ? "N/A" : reader.GetString(3);
                    string stateProvince = reader.IsDBNull(4) ? "N/A" : reader.GetString(4);
                    string countryId = reader.IsDBNull(5) ? "N/A" : reader.GetString(5);

                    Console.WriteLine("Id: " + id);
                    Console.WriteLine("Street Address: " + streetAddress);
                    Console.WriteLine("Postal Code: " + postalCode);
                    Console.WriteLine("City: " + city);
                    Console.WriteLine("State Province: " + stateProvince);
                    Console.WriteLine("Id Country: " + countryId);
                }
            }
            else
            {
                Console.WriteLine("No Locations Found");
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
    public static void InsertHistory(DateTime startDate, int employeeId, DateTime endDate, int departmentId, string jobId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO Histories (start_date, employee_id, end_date, department_id, job_id) VALUES (@startDate, @employeeId, @endDate, @departmentId, @jobId)";
        sqlCommand.Parameters.AddWithValue("@startDate", startDate);
        sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);
        sqlCommand.Parameters.AddWithValue("@endDate", endDate);
        sqlCommand.Parameters.AddWithValue("@departmentId", departmentId);
        sqlCommand.Parameters.AddWithValue("@jobId", jobId);

        try
        {
            _connection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
            }

            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void InsertDepartment(string name, int locationId, int managerId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO Departments (name, location_id, manager_id) VALUES (@name, @locationId, @managerId)";

        try
        {
            _connection.Open();
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@locationId", locationId);
            sqlCommand.Parameters.AddWithValue("@managerId", managerId);

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
            }

            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void InsertLocation(string streetAddress, string postalCode, string city, string stateProvince, int countryId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO Locations (street_address, postal_code, city, state_province, country_id) VALUES (@street_address, @postal_code, @city, @state_province, @country_id)";

        try
        {
            _connection.Open();
            sqlCommand.Parameters.AddWithValue("@street_address", streetAddress);
            sqlCommand.Parameters.AddWithValue("@postal_code", postalCode);
            sqlCommand.Parameters.AddWithValue("@city", city);
            sqlCommand.Parameters.AddWithValue("@state_province", stateProvince);
            sqlCommand.Parameters.AddWithValue("@country_id", countryId);

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
            }

            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }

    public static void InsertCountry(string name, string country_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO Countries values1 (@name), values2 (@country_id)";

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

            SqlParameter pCountryID = new SqlParameter();
            pCountryID.ParameterName = "@country_id";
            pCountryID.SqlDbType = System.Data.SqlDbType.VarChar;
            pCountryID.Value = country_id;
            sqlCommand.Parameters.Add(pCountryID);

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
    public static void UpdateHistory(int employeeId, DateTime startDate, int newEmployeeId, DateTime endDate, int departmentId, string jobId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE Histories SET start_date = @startDate, employee_id = @newEmployeeId, end_date = @endDate, department_id = @departmentId, job_id = @jobId WHERE employee_id = @employeeId";
        sqlCommand.Parameters.AddWithValue("@startDate", startDate);
        sqlCommand.Parameters.AddWithValue("@newEmployeeId", newEmployeeId);
        sqlCommand.Parameters.AddWithValue("@endDate", endDate);
        sqlCommand.Parameters.AddWithValue("@departmentId", departmentId);
        sqlCommand.Parameters.AddWithValue("@jobId", jobId);
        sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);

        try
        {
            _connection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Update Success");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }

            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void UpdateDepartment(int departmentId, string name, int locationId, int managerId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE Departments SET name = @name, location_id = @locationId, manager_id = @managerId WHERE department_id = @departmentId";

        try
        {
            _connection.Open();
            sqlCommand.Parameters.AddWithValue("@departmentId", departmentId);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@locationId", locationId);
            sqlCommand.Parameters.AddWithValue("@managerId", managerId);

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Update Success");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }

            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void UpdateLocation(int id, string streetAddress, string postalCode, string city, string stateProvince, int countryId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE Locations SET StreetAddress = @streetAddress, PostalCode = @postalCode, City = @city, StateProvince = @stateProvince, CountryId = @countryId WHERE Id = @id";

        try
        {
            _connection.Open();
            sqlCommand.Parameters.AddWithValue("@streetAddress", streetAddress);
            sqlCommand.Parameters.AddWithValue("@postalCode", postalCode);
            sqlCommand.Parameters.AddWithValue("@city", city);
            sqlCommand.Parameters.AddWithValue("@stateProvince", stateProvince);
            sqlCommand.Parameters.AddWithValue("@countryId", countryId);
            sqlCommand.Parameters.AddWithValue("@id", id);

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Update Success");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }

            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
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
    public static void DeleteHistory(int employeeId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM Histories WHERE employee_id = @employeeId";
        sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);

        try
        {
            _connection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Delete Success");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }

            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void DeleteDepartment(int departmentId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM Departments WHERE department_id = @departmentId";

        try
        {
            _connection.Open();
            sqlCommand.Parameters.AddWithValue("@departmentId", departmentId);

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Delete Success");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }

            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void DeleteLocation(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM Locations WHERE Id = @id";

        try
        {
            _connection.Open();
            sqlCommand.Parameters.AddWithValue("@id", id);

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Delete Success");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }

            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
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
    public static void GetHistoryByEmployeeId(int employeeId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Histories WHERE employee_id = @employeeId";
        sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("History ID: " + reader.GetInt32(0));
                    Console.WriteLine("Start Date: " + reader.GetDateTime(1).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Employee ID: " + reader.GetInt32(2));
                    Console.WriteLine("End Date: " + reader.GetDateTime(3).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Department ID: " + reader.GetInt32(4));
                    Console.WriteLine("Job ID: " + reader.GetString(5));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No History Found for Employee ID: " + employeeId);
            }

            reader.Close();
            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void GetDepartmentById(int departmentId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Departments WHERE department_id = @departmentId";

        try
        {
            _connection.Open();
            sqlCommand.Parameters.AddWithValue("@departmentId", departmentId);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine("Department ID: " + reader.GetInt32(0));
                Console.WriteLine("Name: " + reader.GetString(1));
                Console.WriteLine("Location ID: " + reader.GetInt32(2));
                Console.WriteLine("Manager ID: " + reader.GetInt32(3));
            }
            else
            {
                Console.WriteLine("Department not found");
            }

            reader.Close();
            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void GetLocationById(int locationId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Locations WHERE location_id = @locationId";

        try
        {
            _connection.Open();
            sqlCommand.Parameters.AddWithValue("@locationId", locationId);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine("Location ID: " + reader.GetInt32(0));
                Console.WriteLine("Street Address: " + reader.GetString(1));
                Console.WriteLine("Postal Code: " + reader.GetString(2));
                Console.WriteLine("City: " + reader.GetString(3));
                Console.WriteLine("State Province: " + reader.GetString(4));
                Console.WriteLine("Country ID: " + reader.GetInt32(5));
            }
            else
            {
                Console.WriteLine("Location not found");
            }

            reader.Close();
            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void GetCountryById(int country_id)
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

