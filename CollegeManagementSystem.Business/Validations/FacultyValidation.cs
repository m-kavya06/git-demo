using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeManagementSystem.Data;

namespace CollegeManagementSystem.Business.Validations
{
    public static class FacultyValidation
    {
        public static int ValidateFacultyId(List<Faculty> faculties)
        {
            int facultyId;
            while (true)
            {
                Console.Write("Enter Faculty ID: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out facultyId) || facultyId <= 0)
                {
                    Console.WriteLine("Invalid Faculty ID. Must be a positive integer.");
                    continue;
                }
                if (faculties.Exists(f => f.FacultyId == facultyId))
                {
                    Console.WriteLine("Faculty ID already exists. Please enter a unique one.");
                    continue;
                }
                break;
            }
            return facultyId;
        }

    }
}
