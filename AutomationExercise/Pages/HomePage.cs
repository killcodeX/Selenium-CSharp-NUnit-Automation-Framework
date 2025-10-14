using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class HomePage : BasePage
    {
        // Locators
        private By sliderCarousel = By.Id("slider-carousel");
        private By signupLoginButton = By.LinkText("Signup / Login");

        public HomePage(IWebDriver driver, int delay) : base(driver, delay) { }

        // Step 1: Navigate
        public void NavigateToHome()
        {
            webDriver.Navigate().GoToUrl("https://automationexercise.com/");
        }

        // Optional: Check if on home page
        public bool IsOnHomePage()
        {
            return IsPageUrlCorrect("https://automationexercise.com/");
        }

        // Step 2: Verify home page visible
        public bool IsHomePageVisible()
        {
            return IsElementVisible(sliderCarousel);
        }

        // Step 3: Click Signup/Login
        public SignupPage ClickSignupLoginForSignup()
        {
            ClickElement(signupLoginButton);
            return new SignupPage(webDriver, 10);
        }

        // For Login flow
        public LoginPage ClickSignupLoginForLogin()
        {
            ClickElement(signupLoginButton);
            return new LoginPage(webDriver, 10);
        }
    }
}