using System;
using System.Collections.Generic;
using MCCArchitecture.Models;

namespace MCCArchitecture.Views
{
    public class VDepartment
    {
        public void GetAll(List<Department> departments)
        {
            if (departments.Count == 0)
            {
                DataEmpty();
            }
            else
            {
                foreach (var department in departments)
                {
                    GetById(department);
                }
            }
        }

        public void GetById(Department department)
        {
            Console.WriteLine("Department ID: " + department.DepartmentId);
            Console.WriteLine("Name: " + department.Name);
            Console.WriteLine("Location ID: " + department.LocationId);
            Console.WriteLine("Manager ID: " + department.ManagerId);
            Console.WriteLine("==========================");
        }

        public void DataEmpty()
        {
            Console.WriteLine("No departments found.");
        }

        public void Success()
        {
            Console.WriteLine("Success!");
        }

        public void Failure()
        {
            Console.WriteLine("Operation failed. Department ID not found.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred while retrieving data.");
        }

        public void DepartmentNotFound()
        {
            Console.WriteLine("Department not found for the given department ID.");
        }

        public int Menu()
        {
            Console.WriteLine("== Menu Department ==");
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

        public Department InsertMenu()
        {
            Console.WriteLine("Enter Department ID: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Department Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Location ID (or leave empty): ");
            int? locationId = null;
            string locationIdInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(locationIdInput))
            {
                locationId = Convert.ToInt32(locationIdInput);
            }

            Console.WriteLine("Enter Manager ID (or leave empty): ");
            int? managerId = null;
            string managerIdInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(managerIdInput))
            {
                managerId = Convert.ToInt32(managerIdInput);
            }

            return new Department
            {
                DepartmentId = departmentId,
                Name = name,
                LocationId = locationId,
                ManagerId = managerId
            };
        }

        public Department UpdateMenu()
        {
            Console.WriteLine("Enter Department ID to Update: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Updated Department Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Updated Location ID (or leave empty): ");
            int? locationId = null;
            string locationIdInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(locationIdInput))
            {
                locationId = Convert.ToInt32(locationIdInput);
            }

            Console.WriteLine("Enter Updated Manager ID (or leave empty): ");
            int? managerId = null;
            string managerIdInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(managerIdInput))
            {
                managerId = Convert.ToInt32(managerIdInput);
            }

            return new Department
            {
                DepartmentId = departmentId,
                Name = name,
                LocationId = locationId,
                ManagerId = managerId
            };
        }

        public int GetDepartmentId()
        {
            Console.WriteLine("Enter Department ID: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Other methods in the class
    }
}
