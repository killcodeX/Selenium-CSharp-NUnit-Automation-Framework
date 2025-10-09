using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class LoginPage : BasePage
    {
        private By email = By.CssSelector("input[data-qa='login-email']");
        private By password = By.CssSelector("input[data-qa='login-password']");
        private By submitBtn = By.CssSelector("button[data-qa='login-button']");

        public LoginPage(IWebDriver driver, int delay) : base(driver, delay) { }

        public LoginPage EnterEmailValue(string value)
        {
            Type(email, value);
            return this;
        }

        public LoginPage EnterPasswordValue(string value)
        {
            Type(password, value);
            return this;
        }

        public LoginPage ClickLogin()
        {
            ClickElement(submitBtn);
            return this;
        }
    }
}
