using System;

namespace Structure
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Admin, Faculty, Student
        
        public void Display()
        {
            Console.WriteLine($"Username: {Username}, Role: {Role}");
        }
    }
}