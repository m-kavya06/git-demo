using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Business.Validations;
using CollegeManagementSystem.Business.Interfaces;

namespace CollegeManagementSystem.Business
{
    public class FacultyManager : IManager<Faculty>
    {
        private List<Faculty> faculties;
        private readonly string filePath = "C:\\Users\\mkavya\\source\\repos\\CollegeManagementSystem\\CollegeManagementSystem\\Files\\faculties.json";
        public FacultyManager()
        {
            faculties = DataStorage.LoadFromFile<Faculty>(filePath);
           
        }
        
        public void Add()
        {
            Faculty f = new Faculty()
            {
                FacultyId = FacultyValidation.ValidateFacultyId(faculties),
                Name = Validation.GetValidName(),
                Department = Validation.GetValidDepartment(),
                Email = Validation.GetValidEmail()
            };
            
            faculties.Add(f);
            DataStorage.SaveToFile(faculties, filePath);
            Console.WriteLine("Faculty added successfully.");
        }

        public void Update()
        {
            Console.WriteLine("Enter Faculty ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int facultyId))
            {
                Console.WriteLine("Invalid Faculty Id Format.");
                return;
            }
            var faculty = faculties.Find(f => f.FacultyId == facultyId);
            if (faculty == null)
            {
                Console.WriteLine("Faculty not found.");
                return;
            }
            Console.WriteLine("Enter new Faculty Name: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                faculty.Name = newName;
            }
            Console.WriteLine("Enter new Faculty Department: ");
            string newDepartment = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDepartment))
            {
                faculty.Department = newDepartment;
            }
            Console.WriteLine("Enter new Email: ");
            faculty.Email = Console.ReadLine();

            DataStorage.SaveToFile(faculties, filePath);
            Console.WriteLine("Faculty updated successfully.");
        }
        public void Delete()
        {
            Console.WriteLine("Enter Faculty ID to delete: ");
            int facultyId = int.Parse(Console.ReadLine());
            var faculty = faculties.Find(f => f.FacultyId == facultyId);
            if (faculty != null)
            {
                faculties.Remove(faculty);
                DataStorage.SaveToFile(faculties, filePath);
                Console.WriteLine("Faculty deleted successfully.");
            }
            else
            {
                Console.WriteLine("Faculty not found.");
            }
        }
        public void View()
        {
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"Faculty ID: {faculty.FacultyId}, Faculty Name: {faculty.Name}, Department: {faculty.Department}, Email: {faculty.Email}");
            }
        }
    }
}
