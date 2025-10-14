

namespace AutomationExercise.Tests
{
    [TestFixture] // Marks this as a test class
    [Order(2)]
    public class LoginTests : BaseTest // Inherit from BaseTest
    {
        private LoginFlow loginFlow;

        [SetUp] // Runs AFTER BaseTest [SetUp]
        public void TestSetup()
        {
            // Create flow objects
            // driver is available because BaseTest already created it
            loginFlow = new LoginFlow(driver);
        }
        [Test, Order(1)]
        [Category("Smoke")]
        [Description("Test Case 1: Login with valid credentials")]
        public void TC02_LoginWithValidCredentials()
        {
            // 2. Run flow
            bool result = loginFlow.ExecuteLoginFlow("testuser82351469@hotmail.com", "Test@123");

            // 3. Assert
            Assert.IsTrue(result);
        }

        [Test, Order(1)]
        [Category("Smoke")]
        [Description("Test Case 2: Login with Invalid credentials")]
        public void TC02_LoginWithInvalidCredentials()
        {
            // 2. Run flow
            bool result = loginFlow.ExecuteLoginFlow("testuser82351469@hotmail.com", "Test");

            // 3. Assert
            Assert.IsTrue(!result);
        }
    }



}