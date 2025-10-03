using OpenQA.Selenium;
/// <summary>
/// tagname[attribute=’value’]
/// </summary>
public class RegisterPage : BasePage
{
    private By name = By.CssSelector("input[data-qa='signup-name']");
    private By email = By.CssSelector("input[data-qa='signup-email']");
    private By submitBtn = By.CssSelector("button[data-qa='signup-button']");

    public RegisterPage(IWebDriver driver, int delay) : base(driver, delay) { }

    public RegisterPage EnterNameValue(string value)
    {
        Type(name, value);
        return this;
    }

    public RegisterPage EnterEmailValue(string value)
    {
        Type(email, value);
        return this;
    }

    public RegisterPage ClickLogin()
    {
        ClickElement(submitBtn);
        return this;
    }
}