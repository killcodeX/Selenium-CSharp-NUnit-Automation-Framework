using OpenQA.Selenium.Chrome;
using NUnit.Framework.Interfaces; // Add this for TestStatus

namespace AutomationExercise.Tests
{
    public class BaseTest
    {
        protected ChromeDriver driver;
        protected int delay = 10;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void conclusion()
        {

            var testName = TestContext.CurrentContext.Test.Name;
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine($"📋 Test: {testName}");
            Console.WriteLine($"📊 Status: {testStatus}");
            Console.WriteLine(new string('=', 60));

            if (testStatus == TestStatus.Failed)
            {
                Console.WriteLine("❌ Test FAILED - Browser will stay open for 15 seconds");
                Thread.Sleep(15000);
            }
            else
            {
                Console.WriteLine("✅ Test PASSED - Browser will stay open for 5 seconds");
                Thread.Sleep(5000);
            }

            Console.WriteLine("🔚 Closing browser...");
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose(); // NUnit1032: Ensure Dispose is called
            }
        }
    }
}
