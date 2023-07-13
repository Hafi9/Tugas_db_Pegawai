using System;
using System.Collections.Generic;
using MCCArchitecture.Models;

namespace MCCArchitecture.Views
{
    public class VCountry
    {
        public void GetAll(List<Country> countries)
        {
            if (countries.Count == 0)
            {
                DataEmpty();
            }
            else
            {
                foreach (var country in countries)
                {
                    GetById(country);
                }
            }
        }

        public void GetById(Country country)
        {
            Console.WriteLine("Country ID: " + country.CountryId);
            Console.WriteLine("Country Name: " + country.CountryName);
            Console.WriteLine("Region ID: " + country.RegionId);
            Console.WriteLine("==========================");
        }

        public void DataEmpty()
        {
            Console.WriteLine("No countries found.");
        }

        public void Success()
        {
            Console.WriteLine("Success!");
        }

        public void Failure()
        {
            Console.WriteLine("Operation failed. Country ID not found.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred while retrieving data.");
        }

        public void CountryNotFound()
        {
            Console.WriteLine("Country not found for the given country ID.");
        }

        public int Menu()
        {
            Console.WriteLine("== Menu Country ==");
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

        public Country InsertMenu()
        {
            Console.WriteLine("Enter Country ID: ");
            string countryId = Console.ReadLine();

            Console.WriteLine("Enter Country Name: ");
            string countryName = Console.ReadLine();

            Console.WriteLine("Enter Region ID: ");
            int regionId = Convert.ToInt32(Console.ReadLine());

            return new Country
            {
                CountryId = countryId,
                CountryName = countryName,
                RegionId = regionId
            };
        }

        public Country UpdateMenu()
        {
            Console.WriteLine("Enter Country ID to Update: ");
            string countryId = Console.ReadLine();

            Console.WriteLine("Enter Updated Country Name: ");
            string countryName = Console.ReadLine();

            Console.WriteLine("Enter Updated Region ID: ");
            int regionId = Convert.ToInt32(Console.ReadLine());

            return new Country
            {
                CountryId = countryId,
                CountryName = countryName,
                RegionId = regionId
            };
        }

        public string GetCountryId()
        {
            Console.WriteLine("Enter Country ID: ");
            return Console.ReadLine();
        }

        // Other methods in the class
    }
}
