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
            Console.WriteLine("Operation failed. Job ID not found.");
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
            Console.WriteLine("1. Add Job");
            Console.WriteLine("2. Update Job");
            Console.WriteLine("3. Delete Job");
            Console.WriteLine("4. Search By ID");
            Console.WriteLine("5. Get All Jobs");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Select an option: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Job InsertMenu()
        {
            Console.WriteLine("Enter Job ID: ");
            string jobId = Console.ReadLine();

            Console.WriteLine("Enter Job Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Minimum Salary: ");
            int minSalary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Maximum Salary: ");
            int maxSalary = Convert.ToInt32(Console.ReadLine());

            return new Job
            {
                JobId = jobId,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
            };
        }

        public Job UpdateMenu()
        {
            Console.WriteLine("Enter Job ID to Update: ");
            string jobId = Console.ReadLine();

            Console.WriteLine("Enter Updated Job Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Updated Minimum Salary: ");
            int minSalary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Updated Maximum Salary: ");
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
    }
}
