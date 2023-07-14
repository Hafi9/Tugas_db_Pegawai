using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MCCArchitecture.Models
{
    public class YourDatabaseContext : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public YourDatabaseContext()
        {
            _connectionString = "Data Source=DESKTOP-MEQ0V63\\MSSQLSERVER01;Initial Catalog=db_pegawai;Integrated Security=True";
        }

        public SqlConnection OpenConnection()
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                return _connection;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }

    public class EmployeeJoin
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public string DepartmentName { get; set; }
        public string StreetAddress { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }

        public List<EmployeeJoin> GetAll()
        {
            using (var context = new YourDatabaseContext())
            {
                var employees = new List<EmployeeJoin>();

                using (var connection = context.OpenConnection())
                {
                    var query = @"SELECT e.employee_id, CONCAT(e.first_name, ' ', e.last_name) AS FullName, e.email, e.phone_number, e.salary, d.name AS DepartmentName, l.street_address AS StreetAddress, c.name AS CountryName, r.name AS RegionName
                                  FROM employees e
                                  JOIN departments d ON e.department_id = d.department_id
                                  JOIN locations l ON d.location_id = l.location_id
                                  JOIN countries c ON l.country_id = c.country_id
                                  JOIN regions r ON c.region_id = r.region_id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var employee = new EmployeeJoin
                                {
                                    EmployeeId = reader.GetInt32(0),
                                    FullName = reader.GetString(1),
                                    Email = reader.GetString(2),
                                    PhoneNumber = reader.GetString(3),
                                    Salary = reader.GetInt32(4),
                                    DepartmentName = reader.GetString(5),
                                    StreetAddress = reader.GetString(6),
                                    CountryName = reader.GetString(7),
                                    RegionName = reader.GetString(8)
                                };

                                employees.Add(employee);
                            }
                        }
                    }
                }

                return employees;
            }
        }
    }
}
