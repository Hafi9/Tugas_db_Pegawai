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
        public int ManagerId { get; set; }
        public string JobId { get; set; }
        public int DepartmentId { get; set; }

        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM employees";

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
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
                                employee.ManagerId = reader.GetInt32(8);
                                employee.JobId = reader.GetString(9);
                                employee.DepartmentId = reader.GetInt32(10);

                                employees.Add(employee);
                            }
                        }
                    }
                }
                catch
                {
                    return new List<Employee>();
                }
            }

            return employees;
        }

        public Employee GetById(int id)
        {
            var employee = new Employee();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM employees WHERE employee_id = @employee_id";
                sqlCommand.Parameters.AddWithValue("@employee_id", id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            employee.EmployeeId = reader.GetInt32(0);
                            employee.FirstName = reader.GetString(1);
                            employee.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                            employee.Email = reader.GetString(3);
                            employee.PhoneNumber = reader.GetString(4);
                            employee.HireDate = reader.GetDateTime(5);
                            employee.Salary = reader.GetInt32(6);
                            employee.CommissionPct = reader.GetDecimal(7);
                            employee.ManagerId = reader.GetInt32(8);
                            employee.JobId = reader.GetString(9);
                            employee.DepartmentId = reader.GetInt32(10);
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }

            return employee;
        }

        public int Insert(Employee employee)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "INSERT INTO employees (first_name, last_name, email, phone_number, hire_date, salary, commission_pct, manager_id, job_id, department_id) VALUES (@first_name, @last_name, @email, @phone_number, @hire_date, @salary, @commission_pct, @manager_id, @job_id, @department_id)";

                sqlCommand.Parameters.AddWithValue("@first_name", employee.FirstName);
                sqlCommand.Parameters.AddWithValue("@last_name", employee.LastName ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@email", employee.Email);
                sqlCommand.Parameters.AddWithValue("@phone_number", employee.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@hire_date", employee.HireDate);
                sqlCommand.Parameters.AddWithValue("@salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("@commission_pct", employee.CommissionPct);
                sqlCommand.Parameters.AddWithValue("@manager_id", employee.ManagerId);
                sqlCommand.Parameters.AddWithValue("@job_id", employee.JobId);
                sqlCommand.Parameters.AddWithValue("@department_id", employee.DepartmentId);

                try
                {
                    connection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
                catch
                {
                    return -1;
                }
            }
        }

        public int Update(Employee employee)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "UPDATE employees SET first_name = @first_name, last_name = @last_name, email = @email, phone_number = @phone_number, "
                                        + "hire_date = @hire_date, salary = @salary, commission_pct = @commission_pct, manager_id = @manager_id, job_id = @job_id, department_id = @department_id WHERE employee_id = @employee_id";

                sqlCommand.Parameters.AddWithValue("@first_name", employee.FirstName);
                sqlCommand.Parameters.AddWithValue("@last_name", employee.LastName ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@email", employee.Email);
                sqlCommand.Parameters.AddWithValue("@phone_number", employee.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@hire_date", employee.HireDate);
                sqlCommand.Parameters.AddWithValue("@salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("@commission_pct", employee.CommissionPct);
                sqlCommand.Parameters.AddWithValue("@manager_id", employee.ManagerId);
                sqlCommand.Parameters.AddWithValue("@job_id", employee.JobId);
                sqlCommand.Parameters.AddWithValue("@department_id", employee.DepartmentId);
                sqlCommand.Parameters.AddWithValue("@employee_id", employee.EmployeeId);

                try
                {
                    connection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
                catch
                {
                    return -1;
                }
            }
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DELETE FROM employees WHERE employee_id = @employee_id";

                sqlCommand.Parameters.AddWithValue("@employee_id", id);

                try
                {
                    connection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
                catch
                {
                    return -1;
                }
            }
        }
    }
}
