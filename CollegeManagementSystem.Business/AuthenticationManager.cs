using CollegeManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Business
{
    public class AuthenticationManager
    {
        private List<User> users;
        private readonly string filePath = "C:\\Users\\mkavya\\source\\repos\\CollegeManagementSystem\\CollegeManagementSystem\\Files\\users.json";
        public AuthenticationManager()
        {
            users = DataStorage.LoadFromFile<User>(filePath);
            
        }
        public User Login(string username, string password, string role)
        {

            return users.Find(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password && user.Role == role);
            
        }
       
        public void RegisterUser(string username, string password, string role)
        {
            var existingUser = users.Find(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Role == role);
            if (existingUser != null)
            {
                Console.WriteLine("User already exists.");
                return;
            }
            var newUser = new User
            {
                Username = username,
                Password = password,
                Role = role
            };

            users.Add(newUser);
            DataStorage.SaveToFile(users, filePath);
            Console.WriteLine($"{role} registered successfully.");
        }
    }
}
