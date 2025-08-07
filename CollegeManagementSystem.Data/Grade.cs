using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Data
{
    public class Grade
    {
        public int RollNumber { get; set; }
        public int CourseId { get; set; }
        public int Marks { get; set; }

        public void Display()
        {
            Console.WriteLine($"Roll No: {RollNumber}, Course ID: {CourseId}, Marks: {Marks}");
        }

    }
}
