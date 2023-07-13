using System;
using System.Collections.Generic;
using MCCArchitecture.Models;

namespace MCCArchitecture.Views
{
    public class VJob
    {
        public void GetAll(List<Job> jobs)
        {
            if (jobs.Count == 0)
            {
                DataEmpty();
            }
            else
            {
                foreach (var job in jobs)
                {
                    GetById(job);
                }
            }
        }

        public void GetById(Job job)
        {
            Console.WriteLine("Job ID: " + job.JobId);
            Console.WriteLine("Title: " + job.Title);
            Console.WriteLine("Min Salary: " + job.MinSalary);
            Console.WriteLine("Max Salary: " + job.MaxSalary);
            Console.WriteLine("==========================");
        }

        public void DataEmpty()
        {
            Console.WriteLine("No jobs found.");
        }

        public void Success()
        {
            Console.WriteLine("Success!");
        }

        public void Failure()
        {
            Console.WriteLine("Operation failed. Job not found.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred while retrieving data.");
        }

        public void JobNotFound()
        {
            Console.WriteLine("Job not found for the given job ID.");
        }

        public int Menu()
        {
            Console.WriteLine("== Menu Job ==");
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

        public Job InsertMenu()
        {
            Console.WriteLine("Enter Job ID: ");
            string jobId = Console.ReadLine();

            Console.WriteLine("Enter Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Min Salary: ");
            int minSalary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Max Salary: ");
            int maxSalary = Convert.ToInt32(Console.ReadLine());

            return new Job
            {
                JobId = jobId,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
            };
        }

        public string GetJobId()
        {
            Console.WriteLine("Enter Job ID: ");
            return Console.ReadLine();
        }

        public Job UpdateMenu(Job job)
        {
            Console.WriteLine("Job ID: " + job.JobId);
            Console.WriteLine("Enter Updated Title (leave empty to keep the existing title): ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                title = job.Title;
            }

            Console.WriteLine("Enter Updated Min Salary (leave empty to keep the existing min salary): ");
            string minSalaryInput = Console.ReadLine();
            int minSalary;
            if (string.IsNullOrWhiteSpace(minSalaryInput))
            {
                minSalary = job.MinSalary;
            }
            else
            {
                minSalary = Convert.ToInt32(minSalaryInput);
            }

            Console.WriteLine("Enter Updated Max Salary (leave empty to keep the existing max salary): ");
            string maxSalaryInput = Console.ReadLine();
            int maxSalary;
            if (string.IsNullOrWhiteSpace(maxSalaryInput))
            {
                maxSalary = job.MaxSalary;
            }
            else
            {
                maxSalary = Convert.ToInt32(maxSalaryInput);
            }

            return new Job
            {
                JobId = job.JobId,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
            };
        }

    }
}
