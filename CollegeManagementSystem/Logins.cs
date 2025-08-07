using CollegeManagementSystem.Dashboard;
using CollegeManagementSystem.Business;
using CollegeManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CollegeManagementSystem
{
    
    public class Logins
    {
       
        public static void AdminLogin()
        {
            Console.WriteLine("Enter Admin Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Admin Password: ");
            string password = Console.ReadLine();
            var authenticateManager = new Business.AuthenticationManager();
            var admin = authenticateManager.Login(username, password, "admin");
            if (admin != null)
            {
                Console.WriteLine("Login Successful");
                AdminDashboard.Show();
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
            }

        }
        public static void StudentLogin()
        {
            Console.WriteLine("Enter Student Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Student Password: ");
            string password = Console.ReadLine();
            var authenticateManager = new Business.AuthenticationManager();
            var student = authenticateManager.Login(username, password, "student");
            if (student != null)
            {
                Console.WriteLine("Login Successful");
                StudentDashboard.Show(username);
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
            }
        }
        public static void FacultyLogin()
        {
            Console.WriteLine("Enter Faculty Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Faculty Password: ");
            string password = Console.ReadLine();
            var authenticateManager = new Business.AuthenticationManager();
            var faculty = authenticateManager.Login(username, password, "faculty");
            if (faculty != null)
            {
                Console.WriteLine("Login Successful");
                FacultyDashboard.Show(username);
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
            }
        }
        public  static void Register(string role)
        {
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            
            var manager = new Business.AuthenticationManager();
            manager.RegisterUser(username, password, role);
        }
    }
}
