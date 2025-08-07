using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CollegeManagementSystem.Business;

namespace CollegeManagementSystem.Dashboard
{
    public class AdminDashboard
    {
        public static void Show()
        {
            var studentManager = new StudentManager();
            var facultyManager = new FacultyManager();
            var courseManager = new CourseManager();
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("1. Manage Students");
                Console.WriteLine("2. Manage Faculty");
                Console.WriteLine("3. Manage Courses");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice: ");
                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        ManageStudents(studentManager); break;
                    case 2:
                        ManageFaculty(facultyManager); break;
                    case 3:
                        ManageCourses(courseManager); break;
                    case 4:
                        flag = false;
                        Console.WriteLine("Logged out successfully");
                        break;
                    default:
                        Console.WriteLine("Invalid option"); break;
                }
            }
        }
        public static void ManageStudents(StudentManager studentManager)
        {
            while(true)
            {
                Console.WriteLine("Manage Students");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Back");
                Console.WriteLine("Enter your choice: ");
                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        studentManager.Add(); break;
                    case 2:
                        studentManager.View(); break;
                    case 3:
                        studentManager.Update(); break;
                    case 4:
                        studentManager.Delete(); break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option"); break;
                }
            }
        }
        public static void ManageFaculty(FacultyManager facultyManager)
        {
            while(true)
            {
                Console.WriteLine("Manage Faculty");
                Console.WriteLine("1. Add Faculty");
                Console.WriteLine("2. View Faculty");
                Console.WriteLine("3. Update Faculty");
                Console.WriteLine("4. Delete Faculty");
                Console.WriteLine("5. Back");
                Console.WriteLine("Enter your choice: ");
                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        facultyManager.Add(); break;
                    case 2:
                        facultyManager.View(); break;
                    case 3:
                        facultyManager.Update(); break;
                    case 4:
                        facultyManager.Delete(); break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option"); break;
                }
            }
        }
        public static void ManageCourses(CourseManager courseManager)
        {
            while (true)
            {
                Console.WriteLine("Manage Courses");
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. View Courses");
                Console.WriteLine("3. Update Course");
                Console.WriteLine("4. Delete Course");
                Console.WriteLine("5. Back");
                Console.WriteLine("Enter your choice: ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        courseManager.Add(); break;
                    case 2:
                        courseManager.View(); break;
                    case 3:
                        courseManager.Update(); break;
                    case 4:
                        courseManager.Delete(); break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option"); break;
                }
            }
        }
    }
}
