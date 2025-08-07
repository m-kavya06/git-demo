using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeManagementSystem.Business;

namespace CollegeManagementSystem.Tests
{
    [TestClass]
    public class AuthenticationManagerTests
    {
        [TestMethod]
        public void AuthenticationManager_CanBeCreated()
        {
            // Simple test to verify AuthenticationManager can be instantiated
            var authManager = new AuthenticationManager();
            Assert.IsNotNull(authManager);
        }
        
        [TestMethod]
        public void AuthenticationManager_HasLoginMethod()
        {
            // Verify Login method exists
            var method = typeof(AuthenticationManager).GetMethod("Login");
            Assert.IsNotNull(method);
        }
        
        [TestMethod]
        public void AuthenticationManager_HasRegisterUserMethod()
        {
            // Verify RegisterUser method exists
            var method = typeof(AuthenticationManager).GetMethod("RegisterUser");
            Assert.IsNotNull(method);
        }
        
        [TestMethod]
        public void AuthenticationManager_InitializesUsersList()
        {
            // Verify that a new AuthenticationManager initializes users list
            var authManager = new AuthenticationManager();
            var usersField = typeof(AuthenticationManager).GetField("users", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var users = usersField?.GetValue(authManager);
            Assert.IsNotNull(users);
        }
    }
}