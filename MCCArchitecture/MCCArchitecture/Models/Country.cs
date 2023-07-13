using System.Collections.Generic;
using System.Data.SqlClient;
using MCCArchitecture.Views;

namespace MCCArchitecture.Models
{
    public class Country
    {
        public string CountryId { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public List<Country> GetAll()
        {
            var countries = new List<Country>();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM Countries";

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
                                country.Name = reader.GetString(1);
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

        public Country GetById(string countryId)
        {
            var country = new Country();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM Countries WHERE country_id = @country_id";
                sqlCommand.Parameters.AddWithValue("@country_id", countryId);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            country.CountryId = reader.GetString(0);
                            country.Name = reader.GetString(1);
                            country.RegionId = reader.GetInt32(2);
                        }
                    }
                }
                catch
                {
                    return new Country();
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
                sqlCommand.CommandText = "INSERT INTO Countries VALUES (@country_id, @name, @region_id)";

                sqlCommand.Parameters.AddWithValue("@country_id", country.CountryId);
                sqlCommand.Parameters.AddWithValue("@name", country.Name);
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
                sqlCommand.CommandText = "UPDATE Countries SET name = @name, region_id = @region_id WHERE country_id = @country_id";

                sqlCommand.Parameters.AddWithValue("@name", country.Name);
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

        public int Delete(string countryId)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DELETE FROM Countries WHERE country_id = @country_id";

                sqlCommand.Parameters.AddWithValue("@country_id", countryId);

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
