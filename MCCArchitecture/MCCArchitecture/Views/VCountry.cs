using System;
using System.Collections.Generic;
using MCCArchitecture.Models;

namespace MCCArchitecture.Views
{
    public class VCountry
    {
        public void GetAll(List<Country> countries)
        {
            foreach (var country in countries)
            {
                GetById(country);
            }
        }

        public void GetById(Country country)
        {
            Console.WriteLine("Country ID: " + country.CountryId);
            Console.WriteLine("Name: " + country.Name);
            Console.WriteLine("Region ID: " + country.RegionId);
            Console.WriteLine("==========================");
        }

        public string GetCountryId()
        {
            Console.WriteLine("Enter Country ID: ");
            string countryId = Console.ReadLine();
            return countryId;
        }

        public string GetCountryName()
        {
            Console.WriteLine("Enter Country Name: ");
            string name = Console.ReadLine();
            return name;
        }

        public int GetRegionId()
        {
            Console.WriteLine("Enter Region ID: ");
            int regionId = Convert.ToInt32(Console.ReadLine());
            return regionId;
        }

        public void CountryNotFound()
        {
            Console.WriteLine("Country not found!");
        }

        public void DataEmpty()
        {
            Console.WriteLine("No country records found.");
        }

        public void Success()
        {
            Console.WriteLine("Operation completed successfully.");
        }

        public void Failure()
        {
            Console.WriteLine("Operation failed. Country not found.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred while retrieving data.");
        }

        public int Menu()
        {
            Console.WriteLine("== Country Menu ==");
            Console.WriteLine("1. Add Country");
            Console.WriteLine("2. Update Country");
            Console.WriteLine("3. Delete Country");
            Console.WriteLine("4. Search by Country ID");
            Console.WriteLine("5. Get All Countries");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Enter your choice: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Country AddCountryMenu()
        {
            Console.WriteLine("Enter Country ID: ");
            string countryId = Console.ReadLine();

            Console.WriteLine("Enter Country Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Region ID: ");
            int regionId = Convert.ToInt32(Console.ReadLine());

            return new Country
            {
                CountryId = countryId,
                Name = name,
                RegionId = regionId
            };
        }

        public Country UpdateCountryMenu()
        {
            Console.WriteLine("Enter Country ID of the Country to Update: ");
            string countryId = Console.ReadLine();

            Console.WriteLine("Enter Updated Country Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Updated Region ID: ");
            int regionId = Convert.ToInt32(Console.ReadLine());

            return new Country
            {
                CountryId = countryId,
                Name = name,
                RegionId = regionId
            };
        }
    }
}
