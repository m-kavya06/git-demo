using CollegeManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Business.Validations
{
    public static class StudentValidation
    {
        
        public static int GetValidRollNumber(List<Student> students)
        {
            int rollNumber;
            while (true)
            {
                Console.Write("Enter Roll Number: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out rollNumber) || rollNumber <= 0)
                {
                    Console.WriteLine("Invalid Roll Number. Must be a positive integer.");
                    continue;
                }
                if (students.Exists(s => s.RollNumber == rollNumber))
                {
                    Console.WriteLine("Roll Number already exists. Please enter a unique one.");
                    continue;
                }
                break;
            }
            return rollNumber;
        }

        
    }
}
