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

        // Step 2: Verify home page visible
        public bool IsHomePageVisible()
        {
            return IsElementVisible(sliderCarousel);
        }

        // Step 3: Click Signup/Login
        public void ClickSignupLogin()
        {
            ClickElement(signupLoginButton);
        }
    }
}