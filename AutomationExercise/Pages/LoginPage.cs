using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class LoginPage : BasePage
    {
        private By email = By.CssSelector("input[data-qa='login-email']");
        private By password = By.CssSelector("input[data-qa='login-password']");
        private By submitBtn = By.CssSelector("button[data-qa='login-button']");
        private By errorMessage = By.CssSelector("p[style*='color: red']");

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

        public HomePage ClickLogin()
        {
            ClickElement(submitBtn);
            return new HomePage(webDriver, 10);
        }
        public bool IsOnLoginPage()
        {
            return IsPageUrlCorrect("https://automationexercise.com/login");
        }

        public bool IsLoginSuccessful()
        {
            // Login is successful if BOTH conditions are true:
            // 1. We left the login page (URL changed)
            // 2. No error message is displayed

            bool leftLoginPage = !IsOnLoginPage();
            bool noError = !IsErrorMessageDisplayed();

            return leftLoginPage && noError;
        }

        // Check if error message is displayed
        public bool IsErrorMessageDisplayed()
        {
            try
            {
                // Wait a bit for error message to appear
                Thread.Sleep(500);
                return IsElementVisible(errorMessage);
            }
            catch
            {
                return false;
            }
        }

        // Get error message text
        public string GetErrorMessageText()
        {
            try
            {
                if (IsErrorMessageDisplayed())
                {
                    return GetText(errorMessage);
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        // Helper method to check if still on login page
        public bool IsStillOnLoginPage()
        {
            return IsOnLoginPage();
        }
    }
}
