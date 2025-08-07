
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Data
{
    public class Student : Person
    {
        public int RollNumber { get; set; }
        public long Phone { get; set; }
        public override void Display()
        {
            Console.WriteLine($"Roll Number: {RollNumber}, Name: {Name}, Department: {Department}, Phone: {Phone}, Email: {Email}");
        } 
    }
}
