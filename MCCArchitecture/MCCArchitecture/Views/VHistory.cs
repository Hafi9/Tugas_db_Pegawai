using System;
using System.Collections.Generic;
using MCCArchitecture.Models;

namespace MCCArchitecture.Views
{
    public class VHistory
    {
        public void GetAll(List<History> histories)
        {
            if (histories.Count == 0)
            {
                DataEmpty();
            }
            else
            {
                foreach (var history in histories)
                {
                    GetById(history);
                }
            }
        }

        public void GetById(History history)
        {
            Console.WriteLine("Start Date: " + history.StartDate);
            Console.WriteLine("Employee ID: " + history.EmployeeId);
            Console.WriteLine("End Date: " + (history.EndDate.HasValue ? history.EndDate.Value.ToString() : "N/A"));
            Console.WriteLine("Department ID: " + (history.DepartmentId.HasValue ? history.DepartmentId.Value.ToString() : "N/A"));
            Console.WriteLine("Job ID: " + history.JobId);
            Console.WriteLine("==========================");
        }

        public void DataEmpty()
        {
            Console.WriteLine("No histories found.");
        }

        public void Success()
        {
            Console.WriteLine("Success!");
        }

        public void Failure()
        {
            Console.WriteLine("Operation failed. History not found.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred while retrieving data.");
        }

        public void HistoryNotFound()
        {
            Console.WriteLine("History not found for the given employee ID.");
        }

        public int Menu()
        {
            Console.WriteLine("== Menu History ==");
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

        public History InsertMenu()
        {
            Console.WriteLine("Enter Start Date (YYYY-MM-DD): ");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter End Date (optional, leave empty if not applicable) (YYYY-MM-DD): ");
            string endDateInput = Console.ReadLine();
            DateTime? endDate = string.IsNullOrEmpty(endDateInput) ? null : (DateTime?)Convert.ToDateTime(endDateInput);

            Console.WriteLine("Enter Department ID (optional, leave empty if not applicable): ");
            string departmentIdInput = Console.ReadLine();
            int? departmentId = string.IsNullOrEmpty(departmentIdInput) ? null : (int?)Convert.ToInt32(departmentIdInput);

            Console.WriteLine("Enter Job ID: ");
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

        public History UpdateMenu()
        {
            Console.WriteLine("Enter Employee ID to Update: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Start Date to Update (YYYY-MM-DD): ");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Updated End Date (optional, leave empty if not applicable) (YYYY-MM-DD): ");
            string endDateInput = Console.ReadLine();
            DateTime? endDate = string.IsNullOrEmpty(endDateInput) ? null : (DateTime?)Convert.ToDateTime(endDateInput);

            Console.WriteLine("Enter Updated Department ID (optional, leave empty if not applicable): ");
            string departmentIdInput = Console.ReadLine();
            int? departmentId = string.IsNullOrEmpty(departmentIdInput) ? null : (int?)Convert.ToInt32(departmentIdInput);

            Console.WriteLine("Enter Updated Job ID: ");
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

        public int GetEmployeeId()
        {
            Console.WriteLine("Enter Employee ID: ");
            return Convert.ToInt32(Console.ReadLine());
        }

    }
}
