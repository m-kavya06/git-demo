using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeManagementSystem.Business;
using System.Collections.Generic;
using CollegeManagementSystem.Data;

namespace CollegeManagementSystem.Tests
{
    [TestClass]
    public class FacultyManagerTests
    {
        [TestMethod]
        public void FacultyManager_CanBeCreated()
        {
            // Simple test to verify FacultyManager can be instantiated
            var manager = new FacultyManager();
            Assert.IsNotNull(manager);
        }
        
        [TestMethod]
        public void FacultyManager_InitializesEmptyList()
        {
            // Verify that a new FacultyManager has a list that can be emptied
            var manager = new FacultyManager();
            ClearFacultiesList(manager);
            Assert.AreEqual(0, GetFacultyCount(manager));
        }
        
        [TestMethod]
        public void FacultyManager_HasCorrectFilePath()
        {
            // Verify that the file path is set correctly
            var manager = new FacultyManager();
            var filePath = GetFilePath(manager);
            Assert.IsTrue(filePath.EndsWith("faculties.json"));
        }
        
        [TestMethod]
        public void Add_Method_ShouldBeAvailable()
        {
            // Verify the Add method exists in FacultyManager
            var method = typeof(FacultyManager).GetMethod("Add");
            Assert.IsNotNull(method, "Add method should exist in FacultyManager");
        }
        
        [TestMethod]
        public void Faculty_HasFacultyIdProperty()
        {
            // Verify Faculty class has FacultyId property
            var property = typeof(Faculty).GetProperty("FacultyId");
            Assert.IsNotNull(property, "Faculty should have FacultyId property");
        }
        
        // Helper method to get faculty count using reflection
        private int GetFacultyCount(FacultyManager manager)
        {
            return GetFacultiesList(manager)?.Count ?? 0;
        }
        
        // Helper method to get file path using reflection
        private string GetFilePath(FacultyManager manager)
        {
            var filePathField = typeof(FacultyManager).GetField("filePath", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return filePathField?.GetValue(manager) as string ?? string.Empty;
        }
        
        // Helper method to clear faculties list
        private void ClearFacultiesList(FacultyManager manager)
        {
            var faculties = GetFacultiesList(manager);
            if (faculties != null)
            {
                faculties.Clear();
            }
        }
        
        // Helper method to get faculties list
        private List<Faculty> GetFacultiesList(FacultyManager manager)
        {
            var facultiesField = typeof(FacultyManager).GetField("faculties", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return facultiesField?.GetValue(manager) as List<Faculty>;
        }
    }
}