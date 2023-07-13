using System.Collections.Generic;
using System.Data.SqlClient;

namespace MCCArchitecture.Models
{
    public class Job
    {
        public string JobId { get; set; }
        public string Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        public List<Job> GetAll()
        {
            var jobs = new List<Job>();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM jobs";

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Job job = new Job();
                                job.JobId = reader.GetString(0);
                                job.Title = reader.GetString(1);
                                job.MinSalary = reader.GetInt32(2);
                                job.MaxSalary = reader.GetInt32(3);

                                jobs.Add(job);
                            }
                        }
                    }
                }
                catch
                {
                    return new List<Job>();
                }
            }

            return jobs;
        }

        public Job GetById(string jobId)
        {
            Job job = null;

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM jobs WHERE job_id = @jobId";
                sqlCommand.Parameters.AddWithValue("@jobId", jobId);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            job = new Job();
                            job.JobId = reader.GetString(0);
                            job.Title = reader.GetString(1);
                            job.MinSalary = reader.GetInt32(2);
                            job.MaxSalary = reader.GetInt32(3);
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }

            return job;
        }

        public int Insert(Job job)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "INSERT INTO jobs (job_id, title, min_salary, max_salary) VALUES (@jobId, @title, @minSalary, @maxSalary)";

                sqlCommand.Parameters.AddWithValue("@jobId", job.JobId);
                sqlCommand.Parameters.AddWithValue("@title", job.Title);
                sqlCommand.Parameters.AddWithValue("@minSalary", job.MinSalary);
                sqlCommand.Parameters.AddWithValue("@maxSalary", job.MaxSalary);

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

        public int Update(Job job)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "UPDATE jobs SET title = @title, min_salary = @minSalary, max_salary = @maxSalary WHERE job_id = @jobId";

                sqlCommand.Parameters.AddWithValue("@title", job.Title);
                sqlCommand.Parameters.AddWithValue("@minSalary", job.MinSalary);
                sqlCommand.Parameters.AddWithValue("@maxSalary", job.MaxSalary);
                sqlCommand.Parameters.AddWithValue("@jobId", job.JobId);

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

        public int Delete(string jobId)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DELETE FROM jobs WHERE job_id = @jobId";

                sqlCommand.Parameters.AddWithValue("@jobId", jobId);

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
