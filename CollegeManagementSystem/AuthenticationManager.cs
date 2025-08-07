using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Structure;

namespace CollegeManagementSystem
{
    public class AuthenticationManager
    {
        private List<User> users;

        public AuthenticationManager()
        {
            users = LoadUsers();
            if (users.Count == 0)
            {
                CreateDefaultUsers();
            }
        }

        public User Login()
        {
            Console.WriteLine("=== Login ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var user = users.Find(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Console.WriteLine($"Login successful! Welcome {user.Username} ({user.Role})");
                return user;
            }
            else
            {
                Console.WriteLine("Invalid credentials!");
                return null;
            }
        }

        private void CreateDefaultUsers()
        {
            users.Add(new User { Username = "admin", Password = "admin123", Role = "Admin" });
            users.Add(new User { Username = "faculty", Password = "faculty123", Role = "Faculty" });
            users.Add(new User { Username = "student", Password = "student123", Role = "Student" });
            SaveUsers();
        }

        private void SaveUsers()
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("users.json", json);
        }

        private List<User> LoadUsers()
        {
            string filePath = "users.json";
            if (!File.Exists(filePath))
            {
                return new List<User>();
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
    }
}