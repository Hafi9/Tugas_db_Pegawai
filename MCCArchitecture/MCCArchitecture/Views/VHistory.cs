using System;
using System.Collections.Generic;
using MCCArchitecture.Models;

namespace MCCArchitecture.Views
{
    public class VHistory
    {
        public void GetAll(List<History> histories)
        {
            foreach (var history in histories)
            {
                GetById(history);
            }
        }

        public void GetById(History history)
        {
            Console.WriteLine("Start Date: " + history.StartDate);
            Console.WriteLine("Employee ID: " + history.EmployeeId);
            Console.WriteLine("End Date: " + history.EndDate);
            Console.WriteLine("Department ID: " + history.DepartmentId);
            Console.WriteLine("Job ID: " + history.JobId);
            Console.WriteLine("==========================");
        }

        public DateTime GetStartDate()
        {
            Console.WriteLine("Enter Start Date (YYYY-MM-DD): ");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());
            return startDate;
        }

        public int GetEmployeeId()
        {
            Console.WriteLine("Enter Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            return employeeId;
        }

        public void HistoryNotFound()
        {
            Console.WriteLine("History not found!");
        }

        public void DataEmpty()
        {
            Console.WriteLine("No history records found.");
        }

        public void Success()
        {
            Console.WriteLine("Operation completed successfully.");
        }

        public void Failure()
        {
            Console.WriteLine("Operation failed. History not found.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred while retrieving data.");
        }

        public int Menu()
        {
            Console.WriteLine("== History Menu ==");
            Console.WriteLine("1. Add History");
            Console.WriteLine("2. Update History");
            Console.WriteLine("3. Delete History");
            Console.WriteLine("4. Search by Start Date and Employee ID");
            Console.WriteLine("5. Get All Histories");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Enter your choice: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public History AddHistoryMenu()
        {
            Console.Write("Masukkan Start Date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Masukkan Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());
            Console.Write("Masukkan End Date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Masukkan Department ID: ");
            int departmentId = int.Parse(Console.ReadLine());
            Console.Write("Masukkan Job ID: ");
            string jobId = Console.ReadLine();

            return new History
            {
                StartDate = startDate,
                EmployeeId = employeeId,
                EndDate = endDate,
                DepartmentId = departmentId,
                JobId = jobId
            };
        }

        public History UpdateHistoryMenu()
        {
            Console.Write("Masukkan Employee ID History yang akan diupdate: ");
            int employeeId = int.Parse(Console.ReadLine());
            Console.Write("Masukkan Start Date baru (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Masukkan Employee ID baru: ");
            int newEmployeeId = int.Parse(Console.ReadLine());
            Console.Write("Masukkan End Date baru (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Masukkan Department ID baru: ");
            int departmentId = int.Parse(Console.ReadLine());
            Console.Write("Masukkan Job ID baru: ");
            string jobId = Console.ReadLine();

            return new History
            {
                StartDate = startDate,
                EmployeeId = employeeId,
                EndDate = endDate,
                DepartmentId = departmentId,
                JobId = jobId
            };
        }
    }
}
