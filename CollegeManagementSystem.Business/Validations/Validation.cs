using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Business.Validations
{
    public static class Validation
    {
        public static string GetValidName()
        {
            while (true)
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[A-Za-z\s]+$"))
                    return name;

                Console.WriteLine("Invalid name. Use letters and spaces only.");
            }
        }

     
        public static string GetValidDepartment()
        {
            while (true)
            {
                Console.Write("Enter Department: ");
                string dept = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dept))
                    return dept;

                Console.WriteLine("Department cannot be empty.");
            }
        }

      
        public static long GetValidPhoneNumber()
        {
            while (true)
            {
                Console.Write("Enter Contact Number: ");
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, @"^\+?\d{10,15}$") && long.TryParse(input, out long phone))
                    return phone;

                Console.WriteLine("Invalid phone number.");
            }
        }

        
        public static string GetValidEmail()
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            while (true)
            {
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                if (emailRegex.IsMatch(email))
                    return email;

                Console.WriteLine("Invalid email format.");
            }
        }
    }
}
