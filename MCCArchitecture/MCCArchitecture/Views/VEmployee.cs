using System;
using System.Collections.Generic;
using MCCArchitecture.Models;

namespace MCCArchitecture.Views
{
    public class VEmployee
    {
        public void GetAll(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                GetById(employee);
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
            Console.WriteLine("Job ID: " + employee.JobId);
            Console.WriteLine("Department ID: " + employee.DepartmentId);
            Console.WriteLine("==========================");
        }

        public int GetEmployeeId()
        {
            Console.WriteLine("Enter Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            return employeeId;
        }

        public void EmployeeNotFound()
        {
            Console.WriteLine("Employee not found!");
        }

        public void DataEmpty()
        {
            Console.WriteLine("No employee records found.");
        }

        public void Success()
        {
            Console.WriteLine("Operation completed successfully.");
        }

        public void Failure()
        {
            Console.WriteLine("Operation failed. Employee not found.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred while retrieving data.");
        }

        public int Menu()
        {
            Console.WriteLine("== Employee Menu ==");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Search by Employee ID");
            Console.WriteLine("5. Get All Employees");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Enter your choice: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Employee AddEmployeeMenu()
        {
            Console.WriteLine("Enter Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
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

            Console.WriteLine("Enter Manager ID: ");
            int managerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Job ID: ");
            string jobId = Console.ReadLine();

            Console.WriteLine("Enter Department ID: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            return new Employee
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                CommissionPct = commissionPct,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId
            };
        }

        public Employee UpdateEmployeeMenu()
        {
            Console.WriteLine("Enter Employee ID of the Employee to Update: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Updated First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Updated Last Name: ");
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

            Console.WriteLine("Enter Updated Manager ID: ");
            int managerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Updated Job ID: ");
            string jobId = Console.ReadLine();

            Console.WriteLine("Enter Updated Department ID: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            return new Employee
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                CommissionPct = commissionPct,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId
            };
        }
    }
}
