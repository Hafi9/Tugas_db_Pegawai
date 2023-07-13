using System.Collections.Generic;
using System.Data.SqlClient;

namespace MCCArchitecture.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public int? ManagerId { get; set; }

        public List<Department> GetAll()
        {
            var departments = new List<Department>();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM departments";

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Department department = new Department();
                                department.DepartmentId = reader.GetInt32(0);
                                department.Name = reader.GetString(1);
                                department.LocationId = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                                department.ManagerId = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3);

                                departments.Add(department);
                            }
                        }
                    }
                }
                catch
                {
                    return new List<Department>();
                }
            }

            return departments;
        }

        public Department GetById(int id)
        {
            var department = new Department();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM departments WHERE department_id = @department_id";
                sqlCommand.Parameters.AddWithValue("@department_id", id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            department.DepartmentId = reader.GetInt32(0);
                            department.Name = reader.GetString(1);
                            department.LocationId = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                            department.ManagerId = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3);
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }

            return department;
        }

        public int Insert(Department department)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "INSERT INTO departments (department_id, name, location_id, manager_id) VALUES (@department_id, @name, @location_id, @manager_id)";

                sqlCommand.Parameters.AddWithValue("@department_id", department.DepartmentId);
                sqlCommand.Parameters.AddWithValue("@name", department.Name);
                sqlCommand.Parameters.AddWithValue("@location_id", department.LocationId ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@manager_id", department.ManagerId ?? (object)DBNull.Value);

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

        public int Update(Department department)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "UPDATE departments SET name = @name, location_id = @location_id, manager_id = @manager_id WHERE department_id = @department_id";

                sqlCommand.Parameters.AddWithValue("@name", department.Name);
                sqlCommand.Parameters.AddWithValue("@location_id", department.LocationId ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@manager_id", department.ManagerId ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@department_id", department.DepartmentId);

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
                sqlCommand.CommandText = "DELETE FROM departments WHERE department_id = @department_id";

                sqlCommand.Parameters.AddWithValue("@department_id", id);

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
