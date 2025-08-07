using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Dashboard;
using CollegeManagementSystem.Business;
using Microsoft.Win32;


namespace CollegeManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            bool continueApp = true;
            
            while (continueApp)
            {
                Console.WriteLine("\nWelcome to College Management System");
                Console.WriteLine("=== LOGIN ===");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. Faculty Login");
                Console.WriteLine("3. Student Login");
                Console.WriteLine("=== REGISTER ===");
                Console.WriteLine("4. Admin Register");
                Console.WriteLine("5. Faculty Register");
                Console.WriteLine("6. Student Register");
                Console.WriteLine("7. Exit");

                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Logins.AdminLogin();
                        break;
                    case 2:
                        Logins.FacultyLogin();
                        break;
                    case 3:
                        Logins.StudentLogin();
                        break;
                    case 4:
                        Logins.Register("admin");
                        break;
                    case 5:
                        Logins.Register("faculty");
                        break;
                    case 6:
                        Logins.Register("student");
                        break;
                    case 7:
                        Console.WriteLine("Thank you for using the System");
                        continueApp = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
        }
    }
}
