using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Data
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }

        public void Display()
        {
            Console.WriteLine($"Course ID: {CourseId}, Course Name: {CourseName}, Credits: {Credits}");
        }

    }
}
