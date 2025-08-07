using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class Student
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }

        public void Display()
        {
            Console.WriteLine($"Roll Number: {RollNumber}, Name: {Name}, Department: {Department}, Phone: {Phone}, Email: {Email}");
        }
    }
}
