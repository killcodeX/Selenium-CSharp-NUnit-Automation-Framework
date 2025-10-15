using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using AutomationExercise.Utils;

namespace AutomationExercise.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected ExtentTest test;

        // Static flag to ensure report is initialized only once
        private static bool isReportInitialized = false;
        private static readonly object lockObject = new object();
        private static int testCount = 0;
        private static int totalTests = 0;

        // This runs BEFORE EACH test
        [SetUp]
        public void Setup()
        {
            // Initialize report ONCE (first test only)
            lock (lockObject)
            {
                if (!isReportInitialized)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("════════════════════════════════════════════════════════════════");
                    Console.WriteLine("           🚀 TEST SUITE EXECUTION STARTED");
                    Console.WriteLine("════════════════════════════════════════════════════════════════");
                    Console.WriteLine($"Start Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    Console.WriteLine();
                    Console.WriteLine("📊 Initializing ExtentReports...");
                    
                    var extent = ExtentManager.GetExtent();
                    
                    Console.WriteLine("✅ ExtentReports initialized successfully\n");
                    isReportInitialized = true;
                }
                testCount++;
            }

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine($"🧪 Test {testCount}: {TestContext.CurrentContext.Test.Name}");
            Console.WriteLine("----------------------------------------");

            try
            {
                // Create test in report
                string testName = TestContext.CurrentContext.Test.Name;
                string testDescription = TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString() ?? "";
                
                test = ExtentTestManager.CreateTest(testName, testDescription);
                Console.WriteLine($"✅ Test created in report: {testName}");
                
                ExtentTestManager.LogInfo($"Test Started: {testName}");

                // Initialize WebDriver
                Console.WriteLine("🌐 Launching Chrome browser...");
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                Console.WriteLine("✅ Browser launched successfully");
                ExtentTestManager.LogInfo("Browser launched successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Setup failed: {ex.Message}");
                throw;
            }
        }

        // This runs AFTER EACH test
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("\n🔍 Test completed. Processing results...");

            try
            {
                // Get test result
                var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
                var errorMessage = TestContext.CurrentContext.Result.Message;
                var stackTrace = TestContext.CurrentContext.Result.StackTrace;

                Console.WriteLine($"Test Status: {testStatus}");

                // Log result based on status
                switch (testStatus)
                {
                    case TestStatus.Failed:
                        Console.WriteLine("❌ Test FAILED");
                        ExtentTestManager.LogFail($"Test Failed: {errorMessage}");
                        
                        // Capture screenshot on failure
                        Console.WriteLine("📸 Capturing screenshot...");
                        string screenshotPath = ScreenshotHelper.CaptureScreenshot(
                            driver, 
                            TestContext.CurrentContext.Test.Name
                        );
                        
                        if (!string.IsNullOrEmpty(screenshotPath))
                        {
                            Console.WriteLine($"✅ Screenshot saved: {screenshotPath}");
                            
                            // Convert to relative path for HTML report
                            // Report is in: Reports/TestReport.html
                            // Screenshot is in: Screenshots/Test.png
                            // Relative path should be: ../Screenshots/Test.png
                            string screenshotFileName = Path.GetFileName(screenshotPath);
                            string relativeScreenshotPath = $"../Screenshots/{screenshotFileName}";
                            
                            test.AddScreenCaptureFromPath(relativeScreenshotPath, "Failure Screenshot");
                            Console.WriteLine($"📎 Screenshot attached to report");
                        }
                        else
                        {
                            Console.WriteLine("⚠️  Screenshot capture failed");
                        }
                        
                        if (!string.IsNullOrEmpty(stackTrace))
                        {
                            ExtentTestManager.LogInfo($"Stack Trace: {stackTrace}");
                        }
                        break;

                    case TestStatus.Passed:
                        Console.WriteLine("✅ Test PASSED");
                        ExtentTestManager.LogPass("Test Passed Successfully");
                        break;

                    case TestStatus.Skipped:
                        Console.WriteLine("⏭️  Test SKIPPED");
                        ExtentTestManager.LogSkip("Test Skipped");
                        break;
                }

                // Close browser
                Console.WriteLine("🔒 Closing browser...");
                driver?.Quit();
                driver?.Dispose();
                ExtentTestManager.LogInfo("Browser closed");
                Console.WriteLine("✅ Browser closed successfully");

                // Check if this is the last test - if so, flush report
                lock (lockObject)
                {
                    // Get total test count from TestContext
                    var context = TestContext.CurrentContext;
                    
                    // If we can't determine total tests, flush after a delay
                    if (testCount >= 4) // Update this number to match your total test count
                    {
                        FlushReportIfLastTest();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ TearDown error: {ex.Message}");
            }
        }

        private void FlushReportIfLastTest()
        {
            // Small delay to ensure all tests are written
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("\n");
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.WriteLine("           📊 GENERATING TEST REPORT");
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            
            ExtentManager.FlushReport();
            
            Console.WriteLine($"End Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.WriteLine("           ✅ TEST SUITE EXECUTION COMPLETED");
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.WriteLine("\n");
        }
    }
}