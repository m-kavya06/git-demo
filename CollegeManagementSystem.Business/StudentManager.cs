using CollegeManagementSystem.Business.Interfaces;
using CollegeManagementSystem.Business.Validations;
using CollegeManagementSystem.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace CollegeManagementSystem.Business
{
    
    public class StudentManager : IManager<Student>
    {
        
        private List<Student> students; // Creation of list to add student details
        private readonly string filePath = "C:\\Users\\mkavya\\source\\repos\\CollegeManagementSystem\\CollegeManagementSystem\\Files\\students.json"; // file path to read and write student deatils

        // Constructor - cannot be async, so use sync version or initialize later
        public StudentManager()
        {
            students = DataStorage.LoadFromFile<Student>(filePath);

        }
        
        
        // Method to add the details of the student
        public void Add()
        {
            Student s = new Student()
            {
                RollNumber = StudentValidation.GetValidRollNumber(students),
                Name = Validation.GetValidName(),
                Department = Validation.GetValidDepartment(),
                Phone = Validation.GetValidPhoneNumber(),
                Email = Validation.GetValidEmail()
            };
            


            students.Add(s);
            DataStorage.SaveToFile(students, filePath); // write the student details to the file
            Console.WriteLine("Student Details added successfully.");
            

        }
        // Method for Displaying Student Details
        public void View()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }
            foreach (var s in students)
            {
                s.Display();
            }
        }

        // Method for Updating the student details
        public void Update()
        {
            try
            {
                Console.WriteLine("Enter Roll Number of student to update: ");
                if (!int.TryParse(Console.ReadLine(), out int studentId))
                {
                    Console.WriteLine("Invalid Roll Number. Please enter a valid number.");
                }
                var student = students.Find(s => s.RollNumber == studentId);
                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                }
                Console.WriteLine("Enter new details for the student:");
                Console.Write("Enter Student Name: ");
                string StudentName = Console.ReadLine();
                if (!string.IsNullOrEmpty(StudentName))
                {
                    student.Name = StudentName;
                }
                Console.Write("Enter Department: ");
                string Department = Console.ReadLine();
                if (!string.IsNullOrEmpty(Department))
                {
                    student.Department = Department;
                }
                Console.Write("Enter ContactNumber: ");
                student.Phone = Convert.ToInt64(Console.ReadLine());
                Console.Write("Enter Email: ");
                student.Email = Console.ReadLine();

                DataStorage.SaveToFile(students, filePath);
                Console.WriteLine("Student details updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
        // Method for searching the student details
        public void SearchStudent()
        {
            Console.WriteLine("Enter Roll Number of student to search: ");
            int rollNumber = int.Parse(Console.ReadLine());

            var student = students.Find(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                student.Display();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        // Method for deleting the student by ID
        public void Delete()
        {
            Console.WriteLine("Enter Roll Number of student to delete: ");
            int rollNumber = int.Parse(Console.ReadLine());

            var student = students.Find(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                students.Remove(student);
                DataStorage.SaveToFile(students, filePath);
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
