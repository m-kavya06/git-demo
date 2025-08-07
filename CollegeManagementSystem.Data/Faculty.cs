using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Data
{
    public class Faculty : Person
    {
        public int FacultyId { get; set; }
        public override void Display()
        {
            Console.WriteLine($"Faculty ID: {FacultyId}, Faculty Name: {Name}, Department: {Department}, Email: {Email}");
        }

    }
}
