using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MCCArchitecture.Models
{
    public class History
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DepartmentId { get; set; }
        public string JobId { get; set; }

        public List<History> GetAll()
        {
            var histories = new List<History>();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM histories";

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                History history = new History();
                                history.StartDate = reader.GetDateTime(0);
                                history.EmployeeId = reader.GetInt32(1);
                                history.EndDate = reader.IsDBNull(2) ? null : (DateTime?)reader.GetDateTime(2);
                                history.DepartmentId = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3);
                                history.JobId = reader.GetString(4);

                                histories.Add(history);
                            }
                        }
                    }
                }
                catch
                {
                    return new List<History>();
                }
            }

            return histories;
        }

        public History GetById(int employeeId)
        {
            var history = new History();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM histories WHERE employee_id = @employee_id";
                sqlCommand.Parameters.AddWithValue("@employee_id", employeeId);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            history.StartDate = reader.GetDateTime(0);
                            history.EmployeeId = reader.GetInt32(1);
                            history.EndDate = reader.IsDBNull(2) ? null : (DateTime?)reader.GetDateTime(2);
                            history.DepartmentId = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3);
                            history.JobId = reader.GetString(4);
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }

            return history;
        }

        public int Insert(History history)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "INSERT INTO histories (start_date, employee_id, end_date, department_id, job_id) VALUES (@start_date, @employee_id, @end_date, @department_id, @job_id)";

                sqlCommand.Parameters.AddWithValue("@start_date", history.StartDate);
                sqlCommand.Parameters.AddWithValue("@employee_id", history.EmployeeId);
                sqlCommand.Parameters.AddWithValue("@end_date", history.EndDate);
                sqlCommand.Parameters.AddWithValue("@department_id", history.DepartmentId);
                sqlCommand.Parameters.AddWithValue("@job_id", history.JobId);

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

        public int Update(History history)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "UPDATE histories SET end_date = @end_date, department_id = @department_id, job_id = @job_id WHERE start_date = @start_date AND employee_id = @employee_id";

                sqlCommand.Parameters.AddWithValue("@end_date", history.EndDate ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@department_id", history.DepartmentId ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@job_id", history.JobId);
                sqlCommand.Parameters.AddWithValue("@start_date", history.StartDate);
                sqlCommand.Parameters.AddWithValue("@employee_id", history.EmployeeId);

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

        public int Delete(int employeeId)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DELETE FROM histories WHERE employee_id = @employee_id";
                sqlCommand.Parameters.AddWithValue("@employee_id", employeeId);

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
