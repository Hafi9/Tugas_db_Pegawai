using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MCCArchitecture.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public decimal CommissionPct { get; set; }
        public int? ManagerId { get; set; }
        public string JobId { get; set; }
        public int? DepartmentId { get; set; }

        public List<Employee> GetAll()
        {

            var employees = new List<Employee>();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM Employees";

                try
                {
                    connection.Open();
                    using SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
                            employee.EmployeeId = reader.GetInt32(0);
                            employee.FirstName = reader.GetString(1);
                            employee.LastName = reader.GetString(2);
                            employee.Email = reader.GetString(3);
                            employee.PhoneNumber = reader.GetString(4);
                            employee.HireDate = reader.GetDateTime(5);
                            employee.Salary = reader.GetInt32(6);
                            employee.CommissionPct = reader.GetDecimal(7);
                            if (!reader.IsDBNull(8))
                                employee.ManagerId = reader.GetInt32(8);
                            employee.JobId = reader.GetString(9);
                            if (!reader.IsDBNull(10))
                                employee.DepartmentId = reader.GetInt32(10);

                            employees.Add(employee);
                        }
                    }
                    else
                    {
                        reader.Close();
                        connection.Close();
                    }

                    return employees;
                }
                catch
                {
                    return new List<Employee>();
                }
            }
            
        }

        public Employee GetById(int employeeId)
        {

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM Employees WHERE EmployeeId = @employee_id";
                sqlCommand.Parameters.AddWithValue("@employee_id", employeeId);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        Employee employee = new Employee();
                        employee.EmployeeId = reader.GetInt32(0);
                        employee.FirstName = reader.GetString(1);
                        employee.LastName = reader.GetString(2);
                        employee.Email = reader.GetString(3);
                        employee.PhoneNumber = reader.GetString(4);
                        employee.HireDate = reader.GetDateTime(5);
                        employee.Salary = reader.GetInt32(6);
                        employee.CommissionPct = reader.GetDecimal(7);
                        if (!reader.IsDBNull(8))
                            employee.ManagerId = reader.GetInt32(8);
                        employee.JobId = reader.GetString(9);
                        if (!reader.IsDBNull(10))
                            employee.DepartmentId = reader.GetInt32(10);

                        reader.Close();
                        connection.Close();

                        return employee;
                    }
                    else
                    {
                        reader.Close();
                        connection.Close();

                        return null;
                    }
                }
                catch
                {
                    connection.Close();
                    return null;
                }
            }
               
        }

        public int Insert(Employee employee)
        {
            var connection = Connection.Get();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, HireDate, Salary, CommissionPct, ManagerId, JobId, DepartmentId) " +
                "VALUES (@first_name, @last_name, @email, @phone_number, @hire_date, @salary, @commision_pct, @manager_id, @job_id, @department_id)";

            sqlCommand.Parameters.AddWithValue("@first_name", employee.FirstName);
            sqlCommand.Parameters.AddWithValue("@last_name", employee.LastName);
            sqlCommand.Parameters.AddWithValue("@email", employee.Email);
            sqlCommand.Parameters.AddWithValue("@phone_number", employee.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@hire_date", employee.HireDate);
            sqlCommand.Parameters.AddWithValue("@salary", employee.Salary);
            sqlCommand.Parameters.AddWithValue("@commision_pct", employee.CommissionPct);
            if (employee.ManagerId.HasValue)
                sqlCommand.Parameters.AddWithValue("@manager_id", employee.ManagerId.Value);
            else
                sqlCommand.Parameters.AddWithValue("@manager_id", DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@job_id", employee.JobId);
            if (employee.DepartmentId.HasValue)
                sqlCommand.Parameters.AddWithValue("@department_id", employee.DepartmentId.Value);
            else
                sqlCommand.Parameters.AddWithValue("@department_id", DBNull.Value);

            try
            {
                connection.Open();
                int result = sqlCommand.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch
            {
                connection.Close();
                return -1;
            }
        }

        public int Update(Employee employee)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "UPDATE Employees SET FirstName = @first_name, LastName = @last_name, Email = @email, " +
                "PhoneNumber = @phone_number, HireDate = @hire_date, Salary = @salary, CommissionPct = @commision_pct, " +
                "ManagerId = @manager_id, JobId = @job_id, DepartmentId = @department_id WHERE EmployeeId = @employee_id";

            sqlCommand.Parameters.AddWithValue("@first_name", employee.FirstName);
            sqlCommand.Parameters.AddWithValue("@last_name", employee.LastName);
            sqlCommand.Parameters.AddWithValue("@email", employee.Email);
            sqlCommand.Parameters.AddWithValue("@phone_number", employee.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@hire_date", employee.HireDate);
            sqlCommand.Parameters.AddWithValue("@salary", employee.Salary);
            sqlCommand.Parameters.AddWithValue("@commision_pct", employee.CommissionPct);
            if (employee.ManagerId.HasValue)
                sqlCommand.Parameters.AddWithValue("@manager_id", employee.ManagerId.Value);
            else
                sqlCommand.Parameters.AddWithValue("@manager_id", DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@job_id", employee.JobId);
            if (employee.DepartmentId.HasValue)
                sqlCommand.Parameters.AddWithValue("@department_id", employee.DepartmentId.Value);
            else
                sqlCommand.Parameters.AddWithValue("@department_id", DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@employee_id", employee.EmployeeId);

            try
            {
                connection.Open();
                int result = sqlCommand.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch
            {
                connection.Close();
                return -1;
            }
        }

        public int Delete(int employeeId)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "DELETE FROM Employees WHERE EmployeeId = @employee_id";

            sqlCommand.Parameters.AddWithValue("@employee_id", employeeId);

            try
            {
                connection.Open();
                int result = sqlCommand.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch
            {
                connection.Close();
                return -1;
            }
        }
    }
}
