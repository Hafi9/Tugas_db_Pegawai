using System.Collections.Generic;
using System.Data.SqlClient;
using MCCArchitecture.Views;

namespace MCCArchitecture.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Region> GetAll()
        {
            var regions = new List<Region>();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM Regions";

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Region region = new Region();
                                region.Id = reader.GetInt32(0);
                                region.Name = reader.GetString(1);

                                regions.Add(region);
                            }
                        }
                    }
                }
                catch
                {
                    return new List<Region>();
                }
            }

            return regions;
        }

        public Region GetById(int id)
        {
            var region = new Region();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM regions WHERE region_id = @region_id";
                sqlCommand.Parameters.AddWithValue("@region_id", id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            region.Id = reader.GetInt32(0);
                            region.Name = reader.GetString(1);
                        }
                    }
                }
                catch
                {
                    return new Region();
                }
            }

            return region;
        }

        public int Insert(Region region)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "INSERT INTO Regions VALUES (@name)";

                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    sqlCommand.Transaction = transaction;

                    try
                    {
                        SqlParameter pName = new SqlParameter();
                        pName.ParameterName = "@name";
                        pName.SqlDbType = System.Data.SqlDbType.VarChar;
                        pName.Value = region.Name;
                        sqlCommand.Parameters.Add(pName);

                        int result = sqlCommand.ExecuteNonQuery();

                        transaction.Commit();
                        return result; // 0 gagal, >= 1 berhasil
                    }
                    catch
                    {
                        transaction.Rollback();
                        return -1; // Kesalahan terjadi pada database
                    }
                }
            }
        }

        public int Update(Region region)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "UPDATE regions SET name = @name WHERE region_id = @region_id";

                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    sqlCommand.Transaction = transaction;

                    try
                    {
                        SqlParameter pName = new SqlParameter();
                        pName.ParameterName = "@name";
                        pName.SqlDbType = System.Data.SqlDbType.VarChar;
                        pName.Value = region.Name;
                        sqlCommand.Parameters.Add(pName);

                        SqlParameter pRegionId = new SqlParameter();
                        pRegionId.ParameterName = "@region_id";
                        pRegionId.SqlDbType = System.Data.SqlDbType.Int;
                        pRegionId.Value = region.Id;
                        sqlCommand.Parameters.Add(pRegionId);

                        int result = sqlCommand.ExecuteNonQuery();

                        transaction.Commit();
                        return result;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
            }
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DELETE FROM regions WHERE region_id = @region_id";

                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    sqlCommand.Transaction = transaction;

                    try
                    {
                        SqlParameter pRegionId = new SqlParameter();
                        pRegionId.ParameterName = "@region_id";
                        pRegionId.SqlDbType = System.Data.SqlDbType.Int;
                        pRegionId.Value = id;
                        sqlCommand.Parameters.Add(pRegionId);

                        int result = sqlCommand.ExecuteNonQuery();

                        transaction.Commit();
                        return result;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
            }
        }
    }
}
