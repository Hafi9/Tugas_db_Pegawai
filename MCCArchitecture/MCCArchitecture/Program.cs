﻿using MCCArchitecture.Controllers;
using MCCArchitecture.Models;
using MCCArchitecture.Views;

namespace MCCArchitecture;

public class Program
{
    public static void Main()
    {
        MainMenu();
    }

    private static void MainMenu()
    {
        bool ulang = true;
        do
        {
            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Regions");
            Console.WriteLine("2. Country");
            Console.WriteLine("3. Location");
            Console.WriteLine("4. Department");
            Console.WriteLine("5. History");
            Console.WriteLine("6. Job");
            Console.WriteLine("7. Employee");
            Console.WriteLine("8. Linq");
            Console.WriteLine("9. Exit");
            Console.WriteLine("Pilih: ");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {
                    case 1:
                        RegionMenu();
                        break;
                    case 2:
                        CountryMenu();
                        break;
                    case 3:
                        LocationMenu();
                        break;
                    case 4:
                        DepartmentMenu();
                        break;
                    case 5:
                        HistoryMenu();
                        break;
                    case 6:
                        JobMenu();
                        break;
                    case 7:
                        EmployeeMenu();
                        break;
                    case 8:
                        LinqMenu();
                        break;
                    case 9:
                        ulang = false;
                        break;
                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-7");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-7!");
            }
        } while (ulang);
    }

    private static void RegionMenu()
    {
        Region region = new Region();
        VRegion vRegion = new VRegion();
        RegionC regionController = new RegionC(region, vRegion);

        bool isTrue = true;
        do
        {
            int pilihMenu = vRegion.Menu();
            switch (pilihMenu)
            {
                case 1:
                    regionController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    regionController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    regionController.Delete();
                    break;
                case 4:
                    regionController.SearchById();
                    break;
                case 5:
                    regionController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void CountryMenu()
    {
        Country country = new Country();
        VCountry vcountry = new VCountry();
        CountryC countryController = new CountryC(country, vcountry);

        bool isTrue = true;
        do
        {
            int pilihMenu = vcountry.Menu();
            switch (pilihMenu)
            {
                case 1:
                    countryController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    countryController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    countryController.Delete();
                    break;
                case 4:
                    countryController.SearchById();
                    break;
                case 5:
                    countryController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }
    private static void LinqMenu()
    {
        bool isTrue = true;
        do
        {
            Console.WriteLine("Pilih menu Linq:");
            Console.WriteLine("1. Tampilkan Join Data");
            Console.WriteLine("2. Kembali ke Menu Utama");
            Console.WriteLine("Pilih: ");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {
                    case 1:
                        ShowJoinData();
                        PressAnyKey();
                        break;
                    case 2:
                        isTrue = false;
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-2!");
            }
        } while (isTrue);
    }


    private static void ShowJoinData()
    {
        EmployeeJoin employeeJoin = new EmployeeJoin();
        var joinData = employeeJoin.GetAll();

        if (joinData.Any())
        {
            Console.WriteLine("Data Join:");
            foreach (var data in joinData)
            {
                Console.WriteLine($"Employee ID: {data.EmployeeId}");
                Console.WriteLine($"Nama Lengkap: {data.FullName}");
                Console.WriteLine($"Email: {data.Email}");
                Console.WriteLine($"Nomor Telepon: {data.PhoneNumber}");
                Console.WriteLine($"Gaji: {data.Salary}");
                Console.WriteLine($"Nama Departemen: {data.DepartmentName}");
                Console.WriteLine($"Alamat: {data.StreetAddress}");
                Console.WriteLine($"Nama Negara: {data.CountryName}");
                Console.WriteLine($"Nama Region: {data.RegionName}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Data Join tidak tersedia.");
        }
    }



    private static void LocationMenu()
    {
        Location location = new Location();
        VLocation vlocation = new VLocation();
        LocationC locationController = new LocationC(location, vlocation);

        bool isTrue = true;
        do
        {
            int pilihMenu = vlocation.Menu();
            switch (pilihMenu)
            {
                case 1:
                    locationController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    locationController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    locationController.Delete();
                    break;
                case 4:
                    locationController.SearchById();
                    break;
                case 5:
                    locationController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }
    private static void DepartmentMenu()
    {
        Department department = new Department();
        VDepartment vdepartment = new VDepartment();
        DepartmentC departmentController = new DepartmentC(department, vdepartment);

        bool isTrue = true;
        do
        {
            int pilihMenu = vdepartment.Menu();
            switch (pilihMenu)
            {
                case 1:
                    departmentController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    departmentController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    departmentController.Delete();
                    break;
                case 4:
                    departmentController.SearchById();
                    break;
                case 5:
                    departmentController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }
    private static void HistoryMenu()
    {
        History history = new History();
        VHistory vhistory = new VHistory();
        HistoryC historyController = new HistoryC(history, vhistory);

        bool isTrue = true;
        do
        {
            int pilihMenu = vhistory.Menu();
            switch (pilihMenu)
            {
                case 1:
                    historyController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    historyController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    historyController.Delete();
                    break;
                case 4:
                    historyController.SearchById();
                    break;
                case 5:
                    historyController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }
    private static void JobMenu()
    {
        Job job = new Job();
        VJob vjob = new VJob();
        JobC jobController = new JobC(job, vjob);

        bool isTrue = true;
        do
        {
            int pilihMenu = vjob.Menu();
            switch (pilihMenu)
            {
                case 1:
                    jobController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    jobController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    jobController.Delete();
                    break;
                case 4:
                    jobController.SearchById();
                    break;
                case 5:
                    jobController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }
    private static void EmployeeMenu()
    {
        Employee employee = new Employee();
        VEmployee vemployee = new VEmployee();
        EmployeeC employeeController = new EmployeeC(employee, vemployee);

        bool isTrue = true;
        do
        {
            int pilihMenu = vemployee.Menu();
            switch (pilihMenu)
            {
                case 1:
                    employeeController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    employeeController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    employeeController.Delete();
                    break;
                case 4:
                    employeeController.SearchById();
                    break;
                case 5:
                    employeeController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void InvalidInput()
    {
        Console.WriteLine("Your input is not valid!");
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
