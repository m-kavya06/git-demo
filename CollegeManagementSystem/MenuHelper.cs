using System;
using Structure;

namespace CollegeManagementSystem
{
    public static class MenuHelper
    {
        public static void ShowMenu(User user, StudentManager sm, FacultyManager fm, CourseManager cm, AttendanceManager am, GradeManager gm)
        {
            while (true)
            {
                Console.WriteLine($"\n=== {user.Role} Menu ===");
                
                if (user.Role == "Admin")
                {
                    Console.WriteLine("1. Manage Students");
                    Console.WriteLine("2. Manage Faculty");
                    Console.WriteLine("3. Manage Courses");
                    Console.WriteLine("4. Exit");
                }
                else if (user.Role == "Faculty")
                {
                    Console.WriteLine("1. View Students");
                    Console.WriteLine("2. Manage Attendance");
                    Console.WriteLine("3. Manage Grades");
                    Console.WriteLine("4. Exit");
                }
                else if (user.Role == "Student")
                {
                    Console.WriteLine("1. View Profile");
                    Console.WriteLine("2. View Grades");
                    Console.WriteLine("3. Exit");
                }

                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                if (choice == "4" || (choice == "3" && user.Role == "Student"))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                HandleMenuChoice(user, choice, sm, fm, cm, am, gm);
            }
        }

        private static void HandleMenuChoice(User user, string choice, StudentManager sm, FacultyManager fm, CourseManager cm, AttendanceManager am, GradeManager gm)
        {
            if (user.Role == "Admin")
            {
                switch (choice)
                {
                    case "1": sm.ViewStudents(); break;
                    case "2": Console.WriteLine("Faculty management..."); break;
                    case "3": cm.ViewCourses(); break;
                }
            }
            else if (user.Role == "Faculty")
            {
                switch (choice)
                {
                    case "1": sm.ViewStudents(); break;
                    case "2": Console.WriteLine("Attendance management..."); break;
                    case "3": Console.WriteLine("Grade management..."); break;
                }
            }
            else if (user.Role == "Student")
            {
                switch (choice)
                {
                    case "1": Console.WriteLine("Profile view..."); break;
                    case "2": Console.WriteLine("Grade view..."); break;
                }
            }
        }
    }
}