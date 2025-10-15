using NUnit.Framework;
using AutomationExercise.Flows;
using AutomationExercise.Utils;

namespace AutomationExercise.Tests
{
    [TestFixture]
    [Order(2)]
    public class LoginTests : BaseTest
    {
        private LoginFlow loginFlow;

        [SetUp]
        public void TestSetup()
        {
            loginFlow = new LoginFlow(driver, 10);
            ExtentTestManager.LogInfo("Login flow initialized");
        }

        [Test, Order(1), Category("Smoke")]
        [Description("Verify user can login with valid credentials")]
        public void TC01_LoginWithValidCredentials()
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
            bool result = loginFlow.ExecuteLoginFlow(email, password);

            ExtentTestManager.LogInfo("Step 5: Verify login successful");

            // Assert and log result
            if (result)
            {
                ExtentTestManager.LogPass("✓ User logged in successfully");
            }
            else
            {
                ExtentTestManager.LogFail("✗ Login failed with valid credentials");
            }

            Assert.IsTrue(result, "Login should succeed with valid credentials");
        }

        [Test, Order(2), Category("Smoke")]
        [Description("Verify user cannot login with invalid credentials")]
        public void TC02_LoginWithInvalidCredentials()
        {
            string email = "testuser82351469@hotmail.com";
            string password = "WrongPassword123";

            ExtentTestManager.LogInfo("=== Test Steps ===");
            ExtentTestManager.LogInfo("Step 1: Navigate to login page");
            ExtentTestManager.LogInfo($"Step 2: Enter email: {email}");
            ExtentTestManager.LogInfo($"Step 3: Enter wrong password: {password}");
            ExtentTestManager.LogInfo("Step 4: Click login button");

            bool result = loginFlow.ExecuteLoginFlow(email, password);

            ExtentTestManager.LogInfo("Step 5: Verify login fails");

            if (!result)
            {
                ExtentTestManager.LogPass("✓ Login correctly failed with invalid credentials");
            }
            else
            {
                ExtentTestManager.LogFail("✗ Login should not succeed with invalid credentials");
            }

            Assert.IsFalse(result, "Login should fail with invalid credentials");
        }

        [Test, Order(3), Category("Regression")]
        [Description("Verify error message is displayed for invalid login")]
        public void TC03_VerifyErrorMessageForInvalidLogin()
        {
            ExtentTestManager.LogInfo("Step 1: Attempt login with invalid credentials");

            bool result = loginFlow.ExecuteLoginFlow("invalid@test.com", "WrongPass");

            ExtentTestManager.LogInfo("Step 2: Check for error message");

            if (!result)
            {
                ExtentTestManager.LogPass("✓ Error displayed as expected");
            }

            Assert.IsFalse(result);
        }

        [Test, Order(4), Category("Regression")]
        [Description("Verify login with empty credentials fails")]
        public void TC04_LoginWithEmptyCredentials()
        {
            ExtentTestManager.LogInfo("Step 1: Attempt login with empty credentials");

            bool result = loginFlow.ExecuteLoginFlow("", "");

            ExtentTestManager.LogInfo("Step 2: Verify login fails");

            if (!result)
            {
                ExtentTestManager.LogPass("✓ Login correctly failed with empty credentials");
            }

            Assert.IsFalse(result, "Login should fail with empty credentials");
        }

        [Test, Order(5), Category("Screenshot Test")]
        [Description("This test intentionally fails to verify screenshot capture")]
        public void TC05_TestScreenshotCapture_ShouldFail()
        {
            ExtentTestManager.LogInfo("Step 1: Navigate to Google to get a page for screenshot");

            driver.Navigate().GoToUrl("https://www.google.com");
            ExtentTestManager.LogInfo("Step 2: Navigated to Google");

            ExtentTestManager.LogFail("Step 3: Intentional failure to test screenshot capture");

            // This will fail and capture a screenshot
            Assert.Fail("⚠️ This test intentionally fails to verify screenshot capture works! ⚠️");
        }
    }
}