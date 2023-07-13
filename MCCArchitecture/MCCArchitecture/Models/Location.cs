using System.Collections.Generic;
using System.Data.SqlClient;

namespace MCCArchitecture.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }

        public List<Location> GetAll()
        {
            var locations = new List<Location>();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM locations";

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Location location = new Location();
                                location.LocationId = reader.GetInt32(0);
                                location.StreetAddress = reader.IsDBNull(1) ? null : reader.GetString(1);
                                location.PostalCode = reader.IsDBNull(2) ? null : reader.GetString(2);
                                location.City = reader.GetString(3);
                                location.StateProvince = reader.IsDBNull(4) ? null : reader.GetString(4);
                                location.CountryId = reader.IsDBNull(5) ? null : reader.GetString(5);

                                locations.Add(location);
                            }
                        }
                    }
                }
                catch
                {
                    return new List<Location>();
                }
            }

            return locations;
        }

        public Location GetById(int id)
        {
            var location = new Location();

            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "SELECT * FROM locations WHERE location_id = @location_id";
                sqlCommand.Parameters.AddWithValue("@location_id", id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            location.LocationId = reader.GetInt32(0);
                            location.StreetAddress = reader.IsDBNull(1) ? null : reader.GetString(1);
                            location.PostalCode = reader.IsDBNull(2) ? null : reader.GetString(2);
                            location.City = reader.GetString(3);
                            location.StateProvince = reader.IsDBNull(4) ? null : reader.GetString(4);
                            location.CountryId = reader.IsDBNull(5) ? null : reader.GetString(5);
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }

            return location;
        }

        public int Insert(Location location)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "INSERT INTO locations (location_id, street_address, postal_code, city, state_province, country_id) VALUES (@location_id, @street_address, @postal_code, @city, @state_province, @country_id)";

                sqlCommand.Parameters.AddWithValue("@location_id", location.LocationId);
                sqlCommand.Parameters.AddWithValue("@street_address", (object)location.StreetAddress ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@postal_code", (object)location.PostalCode ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@city", location.City);
                sqlCommand.Parameters.AddWithValue("@state_province", (object)location.StateProvince ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@country_id", (object)location.CountryId ?? DBNull.Value);

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

        public int Update(Location location)
        {
            using (SqlConnection connection = Connection.Get())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "UPDATE locations SET street_address = @street_address, postal_code = @postal_code, city = @city, state_province = @state_province, country_id = @country_id WHERE location_id = @location_id";

                sqlCommand.Parameters.AddWithValue("@street_address", (object)location.StreetAddress ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@postal_code", (object)location.PostalCode ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@city", location.City);
                sqlCommand.Parameters.AddWithValue("@state_province", (object)location.StateProvince ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@country_id", (object)location.CountryId ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@location_id", location.LocationId);

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
                sqlCommand.CommandText = "DELETE FROM locations WHERE location_id = @location_id";

                sqlCommand.Parameters.AddWithValue("@location_id", id);

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
