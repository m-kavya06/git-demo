using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using CollegeManagementSystem.Data;

namespace CollegeManagementSystem.Business
{
    public class AttendanceManager
    {
        private List<Attendance> records;
        private readonly string filePath = "C:\\Users\\mkavya\\source\\repos\\CollegeManagementSystem\\CollegeManagementSystem\\Files\\attendance.json";
        public AttendanceManager()
        {
            records = DataStorage.LoadFromFile<Attendance>(filePath);
            
        }
        public void Add()
        {
            Attendance a = new Attendance();
            Console.WriteLine("Enter Roll Number: ");
            a.RollNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course ID: ");
            a.CourseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date (dd-mm-yyyy): ");
            a.Date = Console.ReadLine();
            Console.WriteLine("Is Present (yes/no): ");
            string status = Console.ReadLine().ToLower();
            a.IsPresent = status == "yes";

            records.Add(a);
            DataStorage.SaveToFile(records, filePath);
            Console.WriteLine("Attendance marked successfully.");
        }
        public void View()
        {
            foreach (var a in records)
            {
                a.Display();
            }
        }

        public void Update()
        {
            Console.WriteLine("Enter Roll Number: ");
            int rollNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date (dd-mm-yyyy): ");
            string date = Console.ReadLine();

            Attendance entry = records.Find(a => a.RollNumber == rollNumber && a.CourseId == courseId && a.Date == date);
            if (entry != null)
            {
                Console.WriteLine("Is Present (yes/no): ");
                string status = Console.ReadLine().ToLower();
                entry.IsPresent = status == "yes";
                DataStorage.SaveToFile(records, filePath);
                Console.WriteLine("Attendance updated successfully.");
            }
            else
            {
                Console.WriteLine("Attendance not found.");
            }

        }
        
    }
}
