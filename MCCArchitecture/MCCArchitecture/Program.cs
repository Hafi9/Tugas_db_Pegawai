using System.ComponentModel;
using MCCArchitecture.Controllers;
using MCCArchitecture.Models;
using MCCArchitecture.Views;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;
using System;

namespace MCCArchitecture;

public class Program
{
    public static void Main()
    {
        MainMenu();
    }

    private static void MainMenu()
    {
        bool ulang = true;
        do
        {
            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Regions");
            Console.WriteLine("2. Employee");
            Console.WriteLine("3. Department");
            Console.WriteLine("4. Histories");
            Console.WriteLine("5. Jobs");
            Console.WriteLine("6. Location");
            Console.WriteLine("7. Countries");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Pilih: ");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {
                    case 1:
                        RegionMenu();
                        break;
                    case 2:
                        EmployeeMenu();
                        break;
                    case 3:
                        DepartmentMenu();
                        break;
                    case 4:
                        HistoriesMenu();
                        break;
                    case 5:
                        JobsMenu();
                        break;
                    case 6:
                        LocationMenu();
                        break;
                    case 7:
                        CountriesMenu();
                        break;
                    case 8:
                        ulang = false;
                        break;
                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-8");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-8!");
            }
        } while (ulang);
    }
    private static void EmployeeMenu()
    {
        Employee employee = new Employee();
        VEmployee vEmployee = new VEmployee();
        EmployeeController employeeController = new EmployeeController(employee, vEmployee);

        bool isTrue = true;
        do
        {
            int pilihMenu = vEmployee.Menu();
            switch (pilihMenu)
            {
                case 1:
                    employeeController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    employeeController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    employeeController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    employeeController.GetEmployeeById();
                    PressAnyKey();
                    break;
                case 5:
                    employeeController.GetAllEmployees();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void DepartmentMenu()
    {
        Department department = new Department();
        VDepartment vDepartment = new VDepartment();
        DepartmentController departmentController = new DepartmentController(department, vDepartment);

        bool isTrue = true;
        do
        {
            int pilihMenu = vDepartment.Menu();
            switch (pilihMenu)
            {
                case 1:
                    departmentController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    departmentController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    departmentController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    departmentController.GetDepartmentById();
                    PressAnyKey();
                    break;
                case 5:
                    departmentController.GetAllDepartments();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void HistoriesMenu()
    {
        Histories histories = new Histories();
        VHistories vHistories = new VHistories();
        HistoriesController historiesController = new HistoriesController(histories, vHistories);

        bool isTrue = true;
        do
        {
            int pilihMenu = vHistories.Menu();
            switch (pilihMenu)
            {
                case 1:
                    historiesController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    historiesController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    historiesController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    historiesController.GetHistoriesById();
                    PressAnyKey();
                    break;
                case 5:
                    historiesController.GetAllHistories();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void JobsMenu()
    {
        Jobs jobs = new Jobs();
        VJobs vJobs = new VJobs();
        JobsController jobsController = new JobsController(jobs, vJobs);

        bool isTrue = true;
        do
        {
            int pilihMenu = vJobs.Menu();
            switch (pilihMenu)
            {
                case 1:
                    jobsController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    jobsController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    jobsController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    jobsController.GetJobById();
                    PressAnyKey();
                    break;
                case 5:
                    jobsController.GetAllJobs();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void LocationMenu()
    {
        Location location = new Location();
        VLocation vLocation = new VLocation();
        LocationController locationController = new LocationController(location, vLocation);

        bool isTrue = true;
        do
        {
            int pilihMenu = vLocation.Menu();
            switch (pilihMenu)
            {
                case 1:
                    locationController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    locationController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    locationController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    locationController.GetLocationById();
                    PressAnyKey();
                    break;
                case 5:
                    locationController.GetAllLocations();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void CountriesMenu()
    {
        Countries countries = new Countries();
        VCountries vCountries = new VCountries();
        CountriesController countriesController = new CountriesController(countries, vCountries);

        bool isTrue = true;
        do
        {
            int pilihMenu = vCountries.Menu();
            switch (pilihMenu)
            {
                case 1:
                    countriesController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    countriesController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    countriesController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    countriesController.GetCountryById();
                    PressAnyKey();
                    break;
                case 5:
                    countriesController.GetAllCountries();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }
    private static void RegionMenu()
    {
        Region region = new Region();
        VRegion vRegion = new VRegion();
        RegionController regionController = new RegionController(region, vRegion);

        bool isTrue = true;
        do
        {
            int pilihMenu = vRegion.Menu();
            switch (pilihMenu)
            {
                case 1:
                    regionController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    regionController.Update();
                    PressAnyKey();
                    break;
                case 5:
                    regionController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void InvalidInput()
    {
        Console.WriteLine("Your input is not valid!");
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }


    //Get all data
    public static void GetEmployees()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Employees";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Employee ID: " + reader.GetInt32(0));
                    Console.WriteLine("First Name: " + reader.GetString(1));
                    Console.WriteLine("Last Name: " + reader.GetString(2));
                    Console.WriteLine("Email: " + reader.GetString(3));
                    Console.WriteLine("Phone Number: " + reader.GetString(4));
                    Console.WriteLine("Hire Date: " + reader.GetDateTime(5).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Salary: " + reader.GetInt32(6));
                    Console.WriteLine("Commission Pct: " + reader.GetDecimal(7));
                    Console.WriteLine("Manager ID: " + reader.GetInt32(8));
                    Console.WriteLine("Job ID: " + reader.GetString(9));
                    Console.WriteLine("Department ID: " + reader.GetInt32(10));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Employees Found");
            }

            reader.Close();
            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void GetJobs()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Jobs";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Job ID: " + reader.GetString(0));
                    Console.WriteLine("Title: " + reader.GetString(1));
                    Console.WriteLine("Min Salary: " + reader.GetInt32(2));
                    Console.WriteLine("Max Salary: " + reader.GetInt32(3));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Jobs Found");
            }

            reader.Close();
            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
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
                    Console.WriteLine("Start Date: " + reader.GetDateTime(0).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Employee ID: " + reader.GetInt32(1));
                    Console.WriteLine("End Date: " + reader.GetDateTime(2).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Department ID: " + reader.GetInt32(3));
                    Console.WriteLine("Job ID: " + reader.GetString(4));
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
    public static void InsertEmployee(int employeeId, string firstName, string lastName, string email, string phoneNumber, DateTime hireDate, int salary, decimal commision_pct, int managerId, string jobId, int departmentId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO Employees (employee_id, first_name, last_name, email, phone_number, hire_date, salary, commision_pct, manager_id, job_id, department_id) VALUES (@employeeId, @firstName, @lastName, @email, @phoneNumber, @hireDate, @salary, @commision_pct, @managerId, @jobId, @departmentId)";
        sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);
        sqlCommand.Parameters.AddWithValue("@firstName", firstName);
        sqlCommand.Parameters.AddWithValue("@lastName", lastName);
        sqlCommand.Parameters.AddWithValue("@email", email);
        sqlCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
        sqlCommand.Parameters.AddWithValue("@hireDate", hireDate);
        sqlCommand.Parameters.AddWithValue("@salary", salary);
        sqlCommand.Parameters.AddWithValue("@commision_pct", commision_pct);
        sqlCommand.Parameters.AddWithValue("@managerId", managerId);
        sqlCommand.Parameters.AddWithValue("@jobId", jobId);
        sqlCommand.Parameters.AddWithValue("@departmentId", departmentId);

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
    public static void InsertJob(string jobId, string title, decimal minSalary, decimal maxSalary)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO Jobs (job_id, title, min_salary, max_salary) VALUES (@jobId, @title, @minSalary, @maxSalary)";
        sqlCommand.Parameters.AddWithValue("@jobId", jobId);
        sqlCommand.Parameters.AddWithValue("@title", title);
        sqlCommand.Parameters.AddWithValue("@minSalary", minSalary);
        sqlCommand.Parameters.AddWithValue("@maxSalary", maxSalary);

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
    public static void UpdateEmployee(int employeeId, string firstName, string lastName, string email, string phoneNumber, DateTime hireDate, int salary, decimal commision_pct, int managerId, string jobId, int departmentId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE Employees SET first_name = @firstName, last_name = @lastName, email = @email, phone_number = @phoneNumber, hire_date = @hireDate, salary = @salary, commision_pct = @commision_pct, manager_id = @managerId, job_id = @jobId, department_id = @departmentId WHERE employee_id = @employeeId";
        sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);
        sqlCommand.Parameters.AddWithValue("@firstName", firstName);
        sqlCommand.Parameters.AddWithValue("@lastName", lastName);
        sqlCommand.Parameters.AddWithValue("@email", email);
        sqlCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
        sqlCommand.Parameters.AddWithValue("@hireDate", hireDate);
        sqlCommand.Parameters.AddWithValue("@salary", salary);
        sqlCommand.Parameters.AddWithValue("@commision_pct", commision_pct);
        sqlCommand.Parameters.AddWithValue("@managerId", managerId);
        sqlCommand.Parameters.AddWithValue("@jobId", jobId);
        sqlCommand.Parameters.AddWithValue("@departmentId", departmentId);

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
    public static void UpdateJob(string jobId, string title, int minSalary, int maxSalary)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE Jobs SET title = @title, min_salary = @minSalary, max_salary = @maxSalary WHERE job_id = @jobId";
        sqlCommand.Parameters.AddWithValue("@title", title);
        sqlCommand.Parameters.AddWithValue("@minSalary", minSalary);
        sqlCommand.Parameters.AddWithValue("@maxSalary", maxSalary);
        sqlCommand.Parameters.AddWithValue("@jobId", jobId);

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
    public static void DeleteEmployee(int employeeId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM Employees WHERE employee_id = @employeeId";
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
    public static void DeleteJob(string jobId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM Jobs WHERE job_id = @jobId";
        sqlCommand.Parameters.AddWithValue("@jobId", jobId);

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

    //Get by ID
    public static void GetEmployeeById(int employeeId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Employees WHERE employee_id = @employeeId";
        sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Employee ID: " + reader.GetInt32(0));
                    Console.WriteLine("First Name: " + reader.GetString(1));
                    Console.WriteLine("Last Name: " + reader.GetString(2));
                    Console.WriteLine("Email: " + reader.GetString(3));
                    Console.WriteLine("Phone Number: " + reader.GetString(4));
                    Console.WriteLine("Hire Date: " + reader.GetDateTime(5).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Salary: " + reader.GetInt32(6));
                    Console.WriteLine("Commission Pct: " + reader.GetDecimal(7));
                    Console.WriteLine("Manager ID: " + reader.GetInt32(8));
                    Console.WriteLine("Job ID: " + reader.GetString(9));
                    Console.WriteLine("Department ID: " + reader.GetInt32(10));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Employee Found for Employee ID: " + employeeId);
            }

            reader.Close();
            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
    public static void GetJobByJobId(string jobId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM Jobs WHERE job_id = @jobId";
        sqlCommand.Parameters.AddWithValue("@jobId", jobId);

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Job ID: " + reader.GetString(0));
                    Console.WriteLine("Title: " + reader.GetString(1));
                    Console.WriteLine("Min Salary: " + reader.GetInt32(2));
                    Console.WriteLine("Max Salary: " + reader.GetInt32(3));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Job Found for Job ID: " + jobId);
            }

            reader.Close();
            _connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to the database: " + ex.Message);
        }
    }
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
                    Console.WriteLine("Start Date: " + reader.GetDateTime(0).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Employee ID: " + reader.GetInt32(1));
                    Console.WriteLine("End Date: " + reader.GetDateTime(2).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Department ID: " + reader.GetInt32(3));
                    Console.WriteLine("Job ID: " + reader.GetString(4));
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
                int locationId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                int managerId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                Console.WriteLine("Department ID: " + reader.GetInt32(0));
                Console.WriteLine("Name: " + reader.GetString(1));
                Console.WriteLine("Location ID: " + locationId);
                Console.WriteLine("Manager ID: " + managerId);
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

