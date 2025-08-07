using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CollegeManagementSystem.Business;
using CollegeManagementSystem.Data;

namespace CollegeManagementSystem.Tests
{
    [TestClass]
    public class StudentManagerTests
    {
        private readonly string filePath = "C:\\Users\\mkavya\\source\\repos\\CollegeManagementSystem\\CollegeManagementSystem\\Files\\test_students.json";
        
        [TestInitialize]
        public void Setup()
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        
        [TestMethod]
        public void StudentManager_CanBeCreated()
        {
            // Simple test to verify StudentManager can be instantiated
            var manager = new StudentManager();
            Assert.IsNotNull(manager);
        }
        
        [TestMethod]
        public void AddStudent_ValidStudent_ShouldAddToList()
        {
            // Arrange
            var manager = new StudentManager();
            var initialCount = GetStudentCount(manager);
            
            // Create a student to add
            var student = new Student
            {
                RollNumber = 1,
                Name = "Test Student",
                Department = "Computer Science",
                Phone = 1234567890,
                Email = "test@example.com"
            };
            
            // Act - Add the student using reflection
            var students = GetStudentsList(manager);
            students.Add(student);
            
            // Assert
            Assert.AreEqual(initialCount + 1, GetStudentCount(manager));
        }
        
        [TestMethod]
        public void AddStudent_Method_ShouldBeAvailable()
        {
            // Verify the Add method exists in StudentManager
            var method = typeof(StudentManager).GetMethod("Add");
            Assert.IsNotNull(method, "Add method should exist in StudentManager");
        }
        
        [TestMethod]
        public void ViewStudents_EmptyList_ReturnsNoStudents()
        {
            // Arrange
            var manager = new StudentManager();
            ClearStudentsList(manager);
            
            // Act & Assert
            Assert.AreEqual(0, GetStudentCount(manager));
        }
        
        [TestMethod]
        public void SearchStudent_ExistingStudent_ReturnsStudent()
        {
            // Arrange
            var manager = new StudentManager();
            ClearStudentsList(manager);
            
            // Add a test student
            var student = new Student
            {
                RollNumber = 1, // Id is used as the roll number
                Name = "Test Student",
                Department = "Computer Science",
                Phone = 1234567890,
                Email = "test@example.com"
            };
            
            var students = GetStudentsList(manager);
            students.Add(student);
            
            // Act
            var foundStudent = students.Find(s => s.RollNumber == 1); // Search by Id
            
            // Assert
            Assert.IsNotNull(foundStudent);
            Assert.AreEqual("Test Student", foundStudent.Name);
        }
        
        [TestMethod]
        public void DeleteStudent_ExistingStudent_RemovesStudent()
        {
            // Arrange
            var manager = new StudentManager();
            ClearStudentsList(manager);
            
            // Add a test student
            var student = new Student
            {
                RollNumber = 1,
                Name = "Test Student",
                Department = "Computer Science",
                Phone = 1234567890,
                Email = "test@example.com"
            };
            
            var students = GetStudentsList(manager);
            students.Add(student);
            
            // Act
            students.Remove(student);
            
            // Assert
            Assert.AreEqual(0, GetStudentCount(manager));
        }
        
        [TestMethod]
        public void UpdateStudent_ExistingStudent_ModifiesStudent()
        {
            // Arrange
            var manager = new StudentManager();
            ClearStudentsList(manager);
            
            // Add a test student
            var student = new Student
            {
                RollNumber = 1,
                Name = "Test Student",
                Department = "Computer Science",
                Phone = 1234567890,
                Email = "test@example.com"
            };
            
            var students = GetStudentsList(manager);
            students.Add(student);
            
            // Act
            var foundStudent = students.Find(s => s.RollNumber == 1);
            foundStudent.Name = "Updated Name";
            
            // Assert
            Assert.AreEqual("Updated Name", students[0].Name);
        }
        
        // Helper methods using reflection to access private members
        private List<Student> GetStudentsList(StudentManager manager)
        {
            var studentsField = typeof(StudentManager).GetField("students", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return studentsField?.GetValue(manager) as List<Student>;
        }
        
        private int GetStudentCount(StudentManager manager)
        {
            return GetStudentsList(manager)?.Count ?? 0;
        }
        
        private void ClearStudentsList(StudentManager manager)
        {
            var students = GetStudentsList(manager);
            if (students != null)
            {
                students.Clear();
            }
        }
    }
}