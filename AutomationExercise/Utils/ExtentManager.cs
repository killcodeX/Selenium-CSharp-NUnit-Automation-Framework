using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace AutomationExercise.Utils
{
    public class ExtentManager
    {
        private static ExtentReports extent;
        private static string reportPath;

        public static ExtentReports GetExtent()
        {
            if (extent == null)
            {
                // Get project root directory (go up from bin/Debug/net9.0)
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;

                // Create Reports directory in project root
                string reportDir = Path.Combine(projectRoot, "Reports");
                Directory.CreateDirectory(reportDir);
                Console.WriteLine($"📁 Report Directory: {reportDir}");

                // Create report file with timestamp
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                reportPath = Path.Combine(reportDir, $"TestReport_{timestamp}.html");
                Console.WriteLine($"📄 Report File: {reportPath}");

                // Initialize HTML reporter
                var htmlReporter = new ExtentHtmlReporter(reportPath);

                // Configure report appearance
                htmlReporter.Config.DocumentTitle = "Automation Exercise Test Report";
                htmlReporter.Config.ReportName = "Test Execution Report";
                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

                // Initialize ExtentReports
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);

                // Add system information
                extent.AddSystemInfo("Application", "Automation Exercise");
                extent.AddSystemInfo("Environment", "QA");
                extent.AddSystemInfo("User Name", Environment.UserName);
                extent.AddSystemInfo("Machine", Environment.MachineName);
                extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
            }

            return extent;
        }

        public static void FlushReport()
        {
            extent?.Flush();
            Console.WriteLine($"\n📊 Report generated: {reportPath}");
        }
    }
}