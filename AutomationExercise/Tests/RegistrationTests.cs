using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AutomationExercise.TestData;
using AutomationExercise.Flows;

namespace AutomationExercise.Tests
{
    [TestFixture] // Marks this as a test class
    public class RegistrationTests : BaseTest // Inherit from BaseTest
    {
        private RegistrationFlow registrationFlow;

        [SetUp] // Runs AFTER BaseTest [SetUp]
        public void TestSetup()
        {
            // Create flow objects
            // driver is available because BaseTest already created it
            registrationFlow = new RegistrationFlow(driver);
        }

        [Test, Category("Smoke")]
        [Description("Test Case 1: Register with valid credentials")]
        public void TC02_RegisterWithValidCredentials()
        {

            // Arrange - Create test data
            var userData = new UserData
            {
                Name = "John Doe",
                Email = $"testuser{DateTime.Now.Ticks}@example.com",
                Password = "Test@123",
                Title = "Mr",
                Day = "15",
                Month = "5",
                Year = "1990",
                FirstName = "John",
                LastName = "Doe",
                Company = "Test Company",
                Address = "123 Test Street",
                Address2 = "Apt 4B",
                Country = "United States",
                State = "California",
                City = "Los Angeles",
                Zipcode = "90001",
                MobileNumber = "1234567890"
            };

            // 2. Run flow
            bool result = registrationFlow.ExecuteCompleteRegistration(userData);

            // 3. Assert
            Assert.IsTrue(result);


            Thread.Sleep(10000);
        }
    }
}