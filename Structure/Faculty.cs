using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }

        public void Display()
        {
            Console.WriteLine($"Faculty ID: {FacultyId}, Faculty Name: {FacultyName}, Department: {Department}, Email: {Email}");
        }
    }
    
}
