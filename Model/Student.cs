using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem
{
    public class Student
    {
        public int RollNumber { get; set; }
        public string StudentName { get; set; }
        public string Department { get; set; }
        public long ContactNumber { get; set; }
        public string Email { get; set; }

        public void Display()
        {
            Console.WriteLine($"Roll Number: {RollNumber}, Student Name: {StudentName}, Department: {Department}, ContactNumber: {ContactNumber}, Email: {Email}");
        }
    }
}
