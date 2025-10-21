using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace AutomationExercise.Pages
{
    public class BasePage
    {
        protected IWebDriver webDriver;
        protected WebDriverWait wait;
        protected Actions actions;
        public BasePage(IWebDriver driver, int delay)
        {
            webDriver = driver;
            // Initialize Actions class for advanced interactions
            actions = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(delay));
        }

        public void Type(By locator, string value)
        {
            var elem = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            elem.Clear();
            elem.SendKeys(value);
        }

        public void ClickElement(By locator)
        {
            var elem = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            elem.Click();
        }

        // In BasePage.cs - Make it flexible
        public bool IsElementVisible(By locator)
        {
            //Console.WriteLine("I am in IsElementVisible");
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed;
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"[ERROR] Element not visible");
                Console.WriteLine($"Locator: {locator}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return false;
            }
        }

        // OR if you want URL check specifically:
        public bool IsPageUrlCorrect(string expectedUrl)
        {
            try
            {
                Console.WriteLine($"[INFO] Checking URL contains: {expectedUrl}");
                Console.WriteLine($"[INFO] Current URL: {webDriver.Url}");

                wait.Until(ExpectedConditions.UrlContains(expectedUrl));

                Console.WriteLine($"[SUCCESS] URL verification passed!");
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"[ERROR] URL verification failed");
                Console.WriteLine($"Expected: {expectedUrl}");
                Console.WriteLine($"Actual: {webDriver.Url}");
                return false;
            }
        }

        public void SelectRadioOption(By locator)
        {
            var radioOpt = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            radioOpt.Click();
        }

        public void Dropdown(By locator, string value)
        {
            var dropElem = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            var dropdown = new SelectElement(dropElem);
            dropdown.SelectByValue(value);
        }

        public string GetText(By locator)
        {
            try
            {
                // Wait for element to be visible
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
                var element = wait.Until(driver =>
                {
                    var el = driver.FindElement(locator);
                    return el.Displayed ? el : null;
                });

                // Get the text
                return element.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting text from element: {ex.Message}");
                return string.Empty;
            }
        }

        public void HoverAndClick(By element)
        {
            try
            {
                // Fix: Wait for element to be clickable (it already has the element)
                wait.Until(ExpectedConditions.ElementIsVisible(element));
                IWebElement hoverElem = webDriver.FindElement(element);
                actions.MoveToElement(hoverElem).Click().Perform();
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"HoverAndClick error: {ex.Message}");
            }
        }
    }
}

