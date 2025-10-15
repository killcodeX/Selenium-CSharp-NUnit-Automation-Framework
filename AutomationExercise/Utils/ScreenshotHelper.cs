using OpenQA.Selenium;

namespace AutomationExercise.Utils
{
    public class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                // Get project root directory
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;

                // Create Screenshots directory in project root
                string screenshotDir = Path.Combine(projectRoot, "Screenshots");
                Directory.CreateDirectory(screenshotDir);

                // Take screenshot
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();

                // Create filename with timestamp
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"{testName}_{timestamp}.png";
                string filePath = Path.Combine(screenshotDir, fileName);

                // Save screenshot
                screenshot.SaveAsFile(filePath);

                Console.WriteLine($"📸 Screenshot saved: {fileName}");
                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to capture screenshot: {ex.Message}");
                return null;
            }
        }
    }
}