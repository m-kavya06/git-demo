using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CollegeManagementSystem.Data;

namespace CollegeManagementSystem.Business
{
    public class GradeManager
    {
        private List<Grade> grades;
        private readonly string filePath = "C:\\Users\\mkavya\\source\\repos\\CollegeManagementSystem\\CollegeManagementSystem\\Files\\Grades.json";
        public GradeManager()
        {
            grades = DataStorage.LoadFromFile<Grade>(filePath);
            
        }
        
        public void Add()
        {
            Grade grade = new Grade();
            Console.WriteLine("Enter the Roll Number of the student: ");
            grade.RollNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Course ID: ");
            grade.CourseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Marks: ");
            grade.Marks = int.Parse(Console.ReadLine());
            grades.Add(grade);
            DataStorage.SaveToFile(grades, filePath);
            Console.WriteLine("Marks Added Successfully!");
        }

        public void View()
        {
            foreach (var g in grades)
            {
                g.Display();
            }
        }

        public void Update()
        {
            try
            {
                Console.WriteLine("Enter the Roll Number of the student: ");
                int rollNumber = int.Parse(Console.ReadLine());
                var grade = grades.Find(g => g.RollNumber == rollNumber);
                if (grade == null)
                {
                    Console.WriteLine("Grade not found");
                    return;
                }
                Console.WriteLine("Enter the Course ID: ");
                int courseId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new Marks: ");
                int marks = int.Parse(Console.ReadLine());

                DataStorage.SaveToFile(grades, filePath);
                Console.WriteLine("Marks Updated Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
    }
}
