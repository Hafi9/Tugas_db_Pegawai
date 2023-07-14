using System;
using System.Collections.Generic;
using MCCArchitecture.Models;

namespace MCCArchitecture.Views
{
    public class VEmployeeJoin
    {
        public void GetAll(List<EmployeeJoin> employees)
        {
            Console.WriteLine("Data Employees Join:");
            Console.WriteLine("======================");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee ID: {employee.EmployeeId}");
                Console.WriteLine($"Full Name: {employee.FullName}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"Phone Number: {employee.PhoneNumber}");
                Console.WriteLine($"Salary: {employee.Salary}");
                Console.WriteLine($"Department Name: {employee.DepartmentName}");
                Console.WriteLine($"Street Address: {employee.StreetAddress}");
                Console.WriteLine($"Country Name: {employee.CountryName}");
                Console.WriteLine($"Region Name: {employee.RegionName}");
                Console.WriteLine("======================");
            }
        }

        public int GetEmployeeId()
        {
            Console.WriteLine("Enter Employee ID:");
            int employeeId;
            while (!int.TryParse(Console.ReadLine(), out employeeId))
            {
                Console.WriteLine("Invalid input. Please enter a valid Employee ID:");
            }
            return employeeId;
        }

        public void GetById(EmployeeJoin employee)
        {
            Console.WriteLine("Employee Details:");
            Console.WriteLine("======================");
            Console.WriteLine($"Employee ID: {employee.EmployeeId}");
            Console.WriteLine($"Full Name: {employee.FullName}");
            Console.WriteLine($"Email: {employee.Email}");
            Console.WriteLine($"Phone Number: {employee.PhoneNumber}");
            Console.WriteLine($"Salary: {employee.Salary}");
            Console.WriteLine($"Department Name: {employee.DepartmentName}");
            Console.WriteLine($"Street Address: {employee.StreetAddress}");
            Console.WriteLine($"Country Name: {employee.CountryName}");
            Console.WriteLine($"Region Name: {employee.RegionName}");
            Console.WriteLine("======================");
        }

        public void EmployeeNotFound()
        {
            Console.WriteLine("Employee not found.");
        }
    }
}
