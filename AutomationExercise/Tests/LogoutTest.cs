using NUnit.Framework;
using AutomationExercise.Flows;
using AutomationExercise.Utils;

namespace AutomationExercise.Tests
{
    [TestFixture]
    [Order(3)]
    public class LogoutTests : BaseTest
    {
        private LogoutFlow logoutFlow;

        [SetUp]
        public void TestSetup()
        {
            logoutFlow = new LogoutFlow(driver, 10);
            ExtentTestManager.LogInfo("Login flow initialized");
        }

        [Test, Order(1), Category("Smoke")]
        [Description("Verify user can logout")]
        public void TC01_Logout()
        {
            // Test data
            string email = "testuser82351469@hotmail.com";
            string password = "Test@123";

            ExtentTestManager.LogInfo("=== Test Steps ===");
            ExtentTestManager.LogInfo("Step 1: Navigate to login page");
            ExtentTestManager.LogInfo($"Step 2: Enter email: {email}");
            ExtentTestManager.LogInfo("Step 3: Enter password: ********");
            ExtentTestManager.LogInfo("Step 4: Click login button");

            // Execute login
            bool result = logoutFlow.ExecuteLogoutFlow(email, password);

            ExtentTestManager.LogInfo("Step 5: Verify logout successful");

            // Assert and log result
            if (result)
            {
                ExtentTestManager.LogPass("✓ User logged out successfully");
            }
            else
            {
                ExtentTestManager.LogFail("✗ Login failed with valid credentials");
            }

            Assert.IsTrue(result, "Logout should succeed with valid credentials");
        }
    }
}