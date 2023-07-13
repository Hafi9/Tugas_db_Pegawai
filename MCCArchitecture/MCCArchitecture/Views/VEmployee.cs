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
            Console.WriteLine("Manager ID: " + (employee.ManagerId.HasValue ? employee.ManagerId.Value.ToString() : "N/A"));
            Console.WriteLine("Job ID: " + employee.JobId);
            Console.WriteLine("Department ID: " + (employee.DepartmentId.HasValue ? employee.DepartmentId.Value.ToString() : "N/A"));
            Console.WriteLine("==========================");
        }

        public void DataEmpty()
        {
            Console.WriteLine("Data Not Found!");
        }

        public void Success()
        {
            Console.WriteLine("Success!");
        }

        public void Failure()
        {
            Console.WriteLine("Failure!");
        }

        public void Error()
        {
            Console.WriteLine("Error!");
        }

        public int GetEmployeeId()
        {
            Console.WriteLine("Enter Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            return employeeId;
        }

        public Employee InsertMenu()
        {
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Hire Date (yyyy-mm-dd): ");
            DateTime hireDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Commission Pct: ");
            decimal commissionPct = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Manager ID (optional): ");
            int? managerId = Console.ReadLine() != "" ? Convert.ToInt32(Console.ReadLine()) : null;

            Console.WriteLine("Enter Job ID: ");
            string jobId = Console.ReadLine();

            Console.WriteLine("Enter Department ID (optional): ");
            int? departmentId = Console.ReadLine() != "" ? Convert.ToInt32(Console.ReadLine()) : null;

            return new Employee
            {
                EmployeeId = 0,
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

        public Employee UpdateMenu(Employee employee)
        {
            Console.WriteLine("Enter First Name (Current: " + employee.FirstName + "): ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name (Current: " + employee.LastName + "): ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Email (Current: " + employee.Email + "): ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Phone Number (Current: " + employee.PhoneNumber + "): ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Hire Date (Current: " + employee.HireDate.ToString("yyyy-MM-dd") + "): ");
            DateTime hireDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Salary (Current: " + employee.Salary + "): ");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Commission Pct (Current: " + employee.CommissionPct + "): ");
            decimal commissionPct = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Manager ID (Current: " + (employee.ManagerId.HasValue ? employee.ManagerId.Value.ToString() : "N/A") + "): ");
            int? managerId = Console.ReadLine() != "" ? Convert.ToInt32(Console.ReadLine()) : null;

            Console.WriteLine("Enter Job ID (Current: " + employee.JobId + "): ");
            string jobId = Console.ReadLine();

            Console.WriteLine("Enter Department ID (Current: " + (employee.DepartmentId.HasValue ? employee.DepartmentId.Value.ToString() : "N/A") + "): ");
            int? departmentId = Console.ReadLine() != "" ? Convert.ToInt32(Console.ReadLine()) : null;

            return new Employee
            {
                EmployeeId = employee.EmployeeId,
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

        public int Menu()
        {
            Console.WriteLine("== Menu Employee ==");
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

        public void EmployeeNotFound()
        {
            Console.WriteLine("Employee not found!");
        }
    }
}
