using System;
using System.Collections.Generic;
using MCCArchitecture.Models;

namespace MCCArchitecture.Views
{
    public class VLocation
    {
        public void GetAll(List<Location> locations)
        {
            if (locations.Count == 0)
            {
                DataEmpty();
            }
            else
            {
                foreach (var location in locations)
                {
                    GetById(location);
                }
            }
        }

        public void GetById(Location location)
        {
            Console.WriteLine("Location ID: " + location.LocationId);
            Console.WriteLine("Street Address: " + location.StreetAddress);
            Console.WriteLine("Postal Code: " + location.PostalCode);
            Console.WriteLine("City: " + location.City);
            Console.WriteLine("State/Province: " + location.StateProvince);
            Console.WriteLine("Country ID: " + location.CountryId);
            Console.WriteLine("==========================");
        }

        public void DataEmpty()
        {
            Console.WriteLine("No locations found.");
        }

        public void Success()
        {
            Console.WriteLine("Success!");
        }

        public void Failure()
        {
            Console.WriteLine("Operation failed. Location ID not found.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred while retrieving data.");
        }

        public void LocationNotFound()
        {
            Console.WriteLine("Location not found for the given location ID.");
        }

        public int Menu()
        {
            Console.WriteLine("== Menu Location ==");
            Console.WriteLine("1. Tambah");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Hapus");
            Console.WriteLine("4. Search By Id");
            Console.WriteLine("5. Get All");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Pilih: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Location InsertMenu()
        {
            Console.WriteLine("Enter Location ID: ");
            int locationId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Street Address (or leave empty): ");
            string streetAddress = Console.ReadLine();

            Console.WriteLine("Enter Postal Code (or leave empty): ");
            string postalCode = Console.ReadLine();

            Console.WriteLine("Enter City: ");
            string city = Console.ReadLine();

            Console.WriteLine("Enter State/Province (or leave empty): ");
            string stateProvince = Console.ReadLine();

            Console.WriteLine("Enter Country ID (or leave empty): ");
            string countryId = Console.ReadLine();

            return new Location
            {
                LocationId = locationId,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city,
                StateProvince = stateProvince,
                CountryId = countryId
            };
        }

        public Location UpdateMenu()
        {
            Console.WriteLine("Enter Location ID to Update: ");
            int locationId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Updated Street Address (or leave empty): ");
            string streetAddress = Console.ReadLine();

            Console.WriteLine("Enter Updated Postal Code (or leave empty): ");
            string postalCode = Console.ReadLine();

            Console.WriteLine("Enter Updated City: ");
            string city = Console.ReadLine();

            Console.WriteLine("Enter Updated State/Province (or leave empty): ");
            string stateProvince = Console.ReadLine();

            Console.WriteLine("Enter Updated Country ID (or leave empty): ");
            string countryId = Console.ReadLine();

            return new Location
            {
                LocationId = locationId,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city,
                StateProvince = stateProvince,
                CountryId = countryId
            };
        }

        public int GetLocationId()
        {
            Console.WriteLine("Enter Location ID: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Other methods in the class
    }
}
