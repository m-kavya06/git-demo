using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeManagementSystem.Business;
using CollegeManagementSystem.Data;

namespace CollegeManagementSystem.Dashboard
{
    public class StudentDashboard
    {
        
        public static void Show(string studentName)
        {
            
            var studentManager = new StudentManager();
            var attendanceManager = new AttendanceManager();
            var gradeManager = new GradeManager();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. View My Profile");
                Console.WriteLine("2. View Attendance");
                Console.WriteLine("3. View Grades");
                Console.WriteLine("4. Logout");
                Console.WriteLine("Enter your option");
                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        studentManager.SearchStudent(); break;
                    case 2:
                        attendanceManager.View(); break;
                    case 3:
                        gradeManager.View(); break;
                    case 4:
                        flag = false;
                        Console.WriteLine("Logged out succesfully");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;                   

                }
                
                
            }
        }
    }
}
