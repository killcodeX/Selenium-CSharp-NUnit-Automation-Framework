using NUnit.Framework;

namespace AutomationExercise
{
    [TestFixture] // Marks this as a test class
    public class RegistrationTests : BaseTest // Inherit from BaseTest
    {
        private LoginFlow loginFlow;
        //private RegistrationFlow registrationFlow;

        [SetUp] // Runs AFTER BaseTest [SetUp]
        public void TestSetup()
        {
            // Create flow objects
            // driver is available because BaseTest already created it
            loginFlow = new LoginFlow(driver, delay);
            //registrationFlow = new RegistrationFlow(driver, delay);
        }

        // [Test, Category("Smoke")]
        // [Description("Test Case 2: Login with valid credentials")]
        // public void TC02_LoginWithValidCredentials()
        // {
        //     // Arrange
        //     string email = "testuser@example.com";
        //     string password = "Test@123";

        //     // Act
        //     bool isSuccess = loginFlow.ExecuteCompleteLoginFlow(email, password);

        //     // Assert
        //     Assert.IsTrue(isSuccess, "Login should succeed");
        // }
    }
}