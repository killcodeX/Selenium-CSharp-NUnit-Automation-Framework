using NUnit.Framework;
using AutomationExercise.Utils;

namespace AutomationExercise.Tests
{
    /// <summary>
    /// This class runs ONCE for the entire test suite
    /// </summary>
    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Console.WriteLine("\n");
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.WriteLine("           🚀 TEST SUITE EXECUTION STARTED");
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.WriteLine($"Start Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine();

            // Initialize ExtentReports
            Console.WriteLine("📊 Initializing ExtentReports...");
            var extent = ExtentManager.GetExtent();
            Console.WriteLine("✅ ExtentReports initialized successfully\n");
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            Console.WriteLine("\n");
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.WriteLine("           📊 GENERATING TEST REPORT");
            Console.WriteLine("════════════════════════════════════════════════════════════════");

            // Flush the report
            ExtentManager.FlushReport();

            Console.WriteLine($"End Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.WriteLine("           ✅ TEST SUITE EXECUTION COMPLETED");
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.WriteLine("\n");
        }
    }
}