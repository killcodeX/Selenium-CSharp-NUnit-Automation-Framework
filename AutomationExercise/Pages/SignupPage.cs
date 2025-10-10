using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class SignupPage : BasePage
    {
        private By name = By.CssSelector("input[data-qa='signup-name']");
        private By email = By.CssSelector("input[data-qa='signup-email']");
        private By submitBtn = By.CssSelector("button[data-qa='signup-button']");

        public SignupPage(IWebDriver driver, int delay) : base(driver, delay) { }

        public SignupPage EnterNameValue(string value)
        {
            Type(name, value);
            return this;
        }

        public SignupPage EnterEmailValue(string value)
        {
            Type(email, value);
            return this;
        }

        public RegisterPage ClickSignup()
        {
            ClickElement(submitBtn);
            return new RegisterPage(webDriver, 10);
        }

        public bool IsOnSignupPage()
        {
            return IsPageUrlCorrect("https://automationexercise.com/login");
        }
    }
}

