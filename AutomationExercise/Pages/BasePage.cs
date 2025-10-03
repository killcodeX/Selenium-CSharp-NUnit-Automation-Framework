using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
}