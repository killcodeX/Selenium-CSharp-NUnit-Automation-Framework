using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise
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
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose(); // NUnit1032: Ensure Dispose is called
            }
        }
    }
}
