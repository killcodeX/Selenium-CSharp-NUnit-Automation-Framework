using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class HomePage : BasePage
    {
        // Locators
        private By sliderCarousel = By.Id("slider-carousel");
        private By signupLoginButton = By.LinkText("Signup / Login");
        private By loggedInAsText = By.XPath("//a[contains(text(), 'Logged in as')]");
        private By logoutButton = By.LinkText("Logout");
        private By deleteAccButton = By.LinkText("Delete Account");

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

        // for logout
        public LoginPage LogoutAccount()
        {
            if (IsElementVisible(logoutButton))
            {
                ClickElement(logoutButton);
            }

            // Return login page regardless - either we just logged out, 
            // or we were already on the login page
            return new LoginPage(webDriver, 10);
        }

        // for delete account
        public LoginPage DeleteAccount()
        {
            if (IsElementVisible(deleteAccButton))
            {
                ClickElement(deleteAccButton);
            }

            // Return login page regardless - either we just logged out, 
            // or we were already on the login page
            return new LoginPage(webDriver, 10);
        }

        public bool IsLoggedInAsVisible()
        {
            return IsElementVisible(loggedInAsText); // Check the "Logged in as" element
        }
    }
}