using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeManagementSystem.Business;

namespace CollegeManagementSystem.Tests
{
    [TestClass]
    public class DataStorageTests
    {
        [TestMethod]
        public void DataStorage_ClassExists()
        {            
            // Simple test to verify the class exists
            Type type = typeof(DataStorage);
            Assert.IsNotNull(type);
        }
        
        [TestMethod]
        public void DataStorage_HasSaveToFileMethod()
        {
            // Verify SaveToFile method exists
            var method = typeof(DataStorage).GetMethod("SaveToFile");
            Assert.IsNotNull(method);
        }
        
        [TestMethod]
        public void DataStorage_HasLoadFromFileMethod()
        {
            // Verify LoadFromFile method exists
            var method = typeof(DataStorage).GetMethod("LoadFromFile");
            Assert.IsNotNull(method);
        }
    }
}