using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationExercise.Pages
{
    public class BasePage
    {
        protected IWebDriver webDriver;
        protected WebDriverWait wait;
        public BasePage(IWebDriver driver, int delay)
        {
            webDriver = driver;
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
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        // OR if you want URL check specifically:
        public bool IsPageUrlCorrect(string expectedUrl)
        {
            try
            {
                return wait.Until(driver => driver.Url.Contains(expectedUrl));
            }
            catch (WebDriverTimeoutException)
            {
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
    }
}

