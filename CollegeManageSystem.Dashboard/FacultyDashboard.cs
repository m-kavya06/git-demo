using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeManagementSystem.Business;

namespace CollegeManagementSystem.Dashboard
{
    public class FacultyDashboard
    {
        public static void Show(string facultyName)
        {
            var studentManager = new StudentManager();
            var gradeManager = new GradeManager();
            var attendanceManager = new AttendanceManager();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. View Students");
                Console.WriteLine("2. Add Marks of the Student");
                Console.WriteLine("3. Update Marks of the Student");
                Console.WriteLine("4. Mark Attendance of the Student");
                Console.WriteLine("5. Update Attendance of the Student");
                Console.WriteLine("6. Logout");
                Console.WriteLine("Enter your choice: ");
                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        studentManager.View(); break;
                    case 2:
                        gradeManager.Add(); break;
                    case 3:
                        gradeManager.Update(); break;
                    case 4:
                        attendanceManager.Add(); break;
                    case 5:
                        attendanceManager.Update(); break;
                    case 6:
                        flag = false;
                        Console.WriteLine("Logged out successfully!"); break;
                    default:
                        Console.WriteLine("Invalid option!"); break;
                }
            }
        }
    }
}
