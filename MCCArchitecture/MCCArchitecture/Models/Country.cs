using System.Collections.Generic;
using System.Data.SqlClient;
using MCCArchitecture.Views;

namespace MCCArchitecture.Models
{
    public class Country
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public int RegionId { get; set; }

        public List<Country> GetAll()
        {
            var countries = new List<Country>();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM countries";

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Country country = new Country();
                                country.CountryId = reader.GetString(0);
                                country.CountryName = reader.GetString(1);
                                country.RegionId = reader.GetInt32(2);

                                countries.Add(country);
                            }
                        }
                    }
                }
                catch
                {
                    return new List<Country>();
                }
            }

            return countries;
        }

        public Country GetById(string id)
        {
            var country = new Country();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM countries WHERE country_id = @country_id";
                sqlCommand.Parameters.AddWithValue("@country_id", id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            country.CountryId = reader.GetString(0);
                            country.CountryName = reader.GetString(1);
                            country.RegionId = reader.GetInt32(2);
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }

            return country;
        }

        public int Insert(Country country)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "INSERT INTO countries (country_id, name, region_id) VALUES (@country_id, @country_name, @region_id)";

                sqlCommand.Parameters.AddWithValue("@country_id", country.CountryId);
                sqlCommand.Parameters.AddWithValue("@country_name", country.CountryName);
                sqlCommand.Parameters.AddWithValue("@region_id", country.RegionId);

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

        public int Update(Country country)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "UPDATE countries SET name = @country_name, region_id = @region_id WHERE country_id = @country_id";

                sqlCommand.Parameters.AddWithValue("@country_name", country.CountryName);
                sqlCommand.Parameters.AddWithValue("@region_id", country.RegionId);
                sqlCommand.Parameters.AddWithValue("@country_id", country.CountryId);

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

        public int Delete(string id)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DELETE FROM countries WHERE country_id = @country_id";

                sqlCommand.Parameters.AddWithValue("@country_id", id);

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
