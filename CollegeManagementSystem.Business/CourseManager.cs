using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CollegeManagementSystem.Data;

namespace CollegeManagementSystem.Business
{
    public class CourseManager
    {
        private List<Course> courses;
        private readonly string filePath = "C:\\Users\\mkavya\\source\\repos\\CollegeManagementSystem\\CollegeManagementSystem\\Files\\courses.json";
        public CourseManager()
        {
            courses = DataStorage.LoadFromFile<Course>(filePath);
        }
        public void Add()
        {
            Course course = new Course();
            Console.WriteLine("Enter Course ID: ");
            course.CourseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course Name: ");
            course.CourseName = Console.ReadLine();
            Console.WriteLine("Enter Credits: ");
            course.Credits = int.Parse(Console.ReadLine());

            courses.Add(course);
            DataStorage.SaveToFile(courses, filePath);
            Console.WriteLine("Course Added Successfully");
        }
        public void View()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No Courses Found");
                return;
            }
            foreach (var c in courses)
            {
                c.Display();
            }
        }
        public void Update()
        {
            try
            {
                Console.WriteLine("Enter Course ID to Update: ");
                if (!int.TryParse(Console.ReadLine(), out int courseId))
                {
                    throw new FormatException("Invalid Course ID Format");
                }
                var course = courses.Find(c => c.CourseId == courseId);
                if (course == null)
                {
                    Console.WriteLine("Course Not Found");
                }
                Console.WriteLine("Enter New Course Name: ");
                course.CourseName = Console.ReadLine();
                Console.WriteLine("Enter New Credits: ");
                course.Credits = int.Parse(Console.ReadLine());
                DataStorage.SaveToFile(courses, filePath);
                Console.WriteLine("Course Updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void Delete()
        {
            try
            {
                Console.WriteLine("Enter Course ID to Delete: ");
                if (!int.TryParse(Console.ReadLine(), out int courseId))
                {
                    throw new FormatException("Invalid Course ID Format");
                }
                var course = courses.Find(c => c.CourseId == courseId);
                if (course == null)
                {
                    Console.WriteLine("Course Not Found");
                }
                courses.Remove(course);
                DataStorage.SaveToFile(courses, filePath);
                Console.WriteLine("Course Deleted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
