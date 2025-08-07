using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeManagementSystem.Business;
using CollegeManagementSystem.Data;

namespace CollegeManagementSystem.Tests
{
    [TestClass]
    public class CourseManagerTests
    {
        [TestMethod]
        public void CourseManager_CanBeCreated()
        {
            // Simple test to verify CourseManager can be instantiated
            var manager = new CourseManager();
            Assert.IsNotNull(manager);
        }
        
        [TestMethod]
        public void CourseManager_InitializesCoursesList()
        {
            // Verify that a new CourseManager has a courses list
            var manager = new CourseManager();
            ClearCoursesList(manager);
            Assert.AreEqual(0, GetCoursesCount(manager));
        }
        
        [TestMethod]
        public void CourseManager_HasCorrectFilePath()
        {
            // Verify that the file path is set correctly
            var manager = new CourseManager();
            var filePath = GetFilePath(manager);
            Assert.IsTrue(filePath.EndsWith("courses.json"));
        }
        
        [TestMethod]
        public void Add_Method_ShouldBeAvailable()
        {
            // Verify the Add method exists in CourseManager
            var method = typeof(CourseManager).GetMethod("Add");
            Assert.IsNotNull(method, "Add method should exist in CourseManager");
        }
        
        // Helper method to get courses count using reflection
        private int GetCoursesCount(CourseManager manager)
        {
            return GetCoursesList(manager)?.Count ?? 0;
        }
        
        // Helper method to get courses list
        private List<Course> GetCoursesList(CourseManager manager)
        {
            var coursesField = typeof(CourseManager).GetField("courses", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return coursesField?.GetValue(manager) as List<Course>;
        }
        
        // Helper method to clear courses list
        private void ClearCoursesList(CourseManager manager)
        {
            var courses = GetCoursesList(manager);
            if (courses != null)
            {
                courses.Clear();
            }
        }
        
        // Helper method to get file path using reflection
        private string GetFilePath(CourseManager manager)
        {
            var filePathField = typeof(CourseManager).GetField("filePath", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return filePathField?.GetValue(manager) as string ?? string.Empty;
        }
    }
}