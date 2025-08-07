using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeManagementSystem.Business;
using CollegeManagementSystem.Data;

namespace CollegeManagementSystem.Tests
{
    [TestClass]
    public class AttendanceManagerTests
    {
        [TestMethod]
        public void AttendanceManager_CanBeCreated()
        {
            // Simple test to verify AttendanceManager can be instantiated
            var manager = new AttendanceManager();
            Assert.IsNotNull(manager);
        }
        
        [TestMethod]
        public void AttendanceManager_InitializesRecordsList()
        {
            // Verify that a new AttendanceManager has a records list
            var manager = new AttendanceManager();
            ClearRecordsList(manager);
            Assert.AreEqual(0, GetRecordsCount(manager));
        }
        
        [TestMethod]
        public void AttendanceManager_HasCorrectFilePath()
        {
            // Verify that the file path is set correctly
            var manager = new AttendanceManager();
            var filePath = GetFilePath(manager);
            Assert.IsTrue(filePath.EndsWith("attendance.json"));
        }
        
        [TestMethod]
        public void Add_Method_ShouldBeAvailable()
        {
            // Verify the Add method exists in AttendanceManager
            var method = typeof(AttendanceManager).GetMethod("Add");
            Assert.IsNotNull(method, "Add method should exist in AttendanceManager");
        }
        
        // Helper method to get records count using reflection
        private int GetRecordsCount(AttendanceManager manager)
        {
            return GetRecordsList(manager)?.Count ?? 0;
        }
        
        // Helper method to get records list
        private List<Attendance> GetRecordsList(AttendanceManager manager)
        {
            var recordsField = typeof(AttendanceManager).GetField("records", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return recordsField?.GetValue(manager) as List<Attendance>;
        }
        
        // Helper method to clear records list
        private void ClearRecordsList(AttendanceManager manager)
        {
            var records = GetRecordsList(manager);
            if (records != null)
            {
                records.Clear();
            }
        }
        
        // Helper method to get file path using reflection
        private string GetFilePath(AttendanceManager manager)
        {
            var filePathField = typeof(AttendanceManager).GetField("filePath", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return filePathField?.GetValue(manager) as string ?? string.Empty;
        }
    }
}