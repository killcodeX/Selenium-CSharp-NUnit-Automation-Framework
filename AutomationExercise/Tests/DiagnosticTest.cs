using NUnit.Framework;
using System.Threading;

namespace AutomationExercise.Tests
{
    [TestFixture]
    public class DiagnosticTest : BaseTest
    {
        [Test]
        public void SimpleBrowserTest()
        {
            Console.WriteLine("🚀 Test Started");

            // Navigate to a website
            driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine("✅ Navigated to Google");

            // Wait and print
            Console.WriteLine("⏸️  Waiting 5 seconds...");
            Thread.Sleep(5000);

            Console.WriteLine("✅ Test Complete - Check if browser is visible!");
        }
    }
}