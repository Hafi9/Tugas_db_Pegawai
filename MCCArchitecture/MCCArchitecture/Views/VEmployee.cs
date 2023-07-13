using System;
using System.Collections.Generic;
using MCCArchitecture.Models;

namespace MCCArchitecture.Views
{
    public class VEmployee
    {
        public void GetAll(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                DataEmpty();
            }
            else
            {
                foreach (var employee in employees)
                {
                    GetById(employee);
                }
            }
        }

        public void GetById(Employee employee)
        {
            Console.WriteLine("Employee ID: " + employee.EmployeeId);
            Console.WriteLine("First Name: " + employee.FirstName);
            Console.WriteLine("Last Name: " + employee.LastName);
            Console.WriteLine("Email: " + employee.Email);
            Console.WriteLine("Phone Number: " + employee.PhoneNumber);
            Console.WriteLine("Hire Date: " + employee.HireDate);
            Console.WriteLine("Salary: " + employee.Salary);
            Console.WriteLine("Commission Pct: " + employee.CommissionPct);
            Console.WriteLine("Manager ID: " + employee.ManagerId);
            Console.WriteLine("Department ID: " + employee.DepartmentId);
            Console.WriteLine("==========================");
        }

        public void DataEmpty()
        {
            Console.WriteLine("No employees found.");
        }

        public void Success()
        {
            Console.WriteLine("Success!");
        }

        public void Failure()
        {
            Console.WriteLine("Operation failed. Employee ID not found.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred while retrieving data.");
        }

        public void EmployeeNotFound()
        {
            Console.WriteLine("Employee not found for the given employee ID.");
        }

        public int Menu()
        {
            Console.WriteLine("== Menu Employee ==");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Search By Id");
            Console.WriteLine("5. Get All");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Pilih: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Employee InsertMenu()
        {
            Console.WriteLine("Enter Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name (or leave empty): ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Hire Date (YYYY-MM-DD): ");
            DateTime hireDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Commission Pct: ");
            decimal commissionPct = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Manager ID (or leave empty): ");
            int managerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Department ID: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            return new Employee
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = string.IsNullOrEmpty(lastName) ? null : lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                CommissionPct = commissionPct,
                ManagerId = managerId,
                DepartmentId = departmentId
            };
        }

        public Employee UpdateMenu(Employee employee)
        {
            Console.WriteLine("Enter Employee ID to Update: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Updated First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Updated Last Name (or leave empty): ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Updated Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Updated Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Updated Hire Date (YYYY-MM-DD): ");
            DateTime hireDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Updated Salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Updated Commission Pct: ");
            decimal commissionPct = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Updated Manager ID (or leave empty): ");
            int managerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Updated Department ID: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            return new Employee
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = string.IsNullOrEmpty(lastName) ? null : lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                CommissionPct = commissionPct,
                ManagerId = managerId,
                DepartmentId = departmentId
            };
        }

        public int GetEmployeeId()
        {
            Console.WriteLine("Enter Employee ID: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
