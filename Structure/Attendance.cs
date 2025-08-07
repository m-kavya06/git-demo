using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class Attendance
    {
        public int RollNumber { get; set; }
        public int CourseId { get; set; }
        public string Date { get; set; }
        public bool IsPresent { get; set; }

        public void Display()
        {
            string status = IsPresent ? "Present" : "Absent";
            Console.WriteLine($"Roll Number: {RollNumber}, Course ID: {CourseId}, Date: {Date}, Status: {status}");
        }
    }
}
