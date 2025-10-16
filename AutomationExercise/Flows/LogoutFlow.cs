using OpenQA.Selenium;
using AutomationExercise.Pages;
using AutomationExercise.TestData;

// Flow case 1

namespace AutomationExercise.Flows
{
    public class LogoutFlow
    {
        private IWebDriver driver;
        private int delay;

        public LogoutFlow(IWebDriver driver, int delay = 20)
        {
            this.driver = driver;
            this.delay = delay;
        }

        public bool ExecuteLogoutFlow(string email, string password)
        {
            try
            {
                // Step 1-2: Navigate to home and verify
                var homePage = new HomePage(driver, delay);
                homePage.NavigateToHome();

                if (!homePage.IsHomePageVisible())
                {
                    Console.WriteLine("[ERROR] Home page is not visible");
                    return false;
                }
                Console.WriteLine("[SUCCESS] Home page is visible");

                // Step 3: Click Signup/Login
                var loginPage = homePage.ClickSignupLoginForLogin();

                // Verify we're on login page
                if (!loginPage.IsOnLoginPage())
                {
                    Console.WriteLine("[ERROR] Not on login page");
                    return false;
                }
                Console.WriteLine("[SUCCESS] On login page");

                // Step 4: Enter credentials and click login
                loginPage
                    .EnterEmailValue(email)
                    .EnterPasswordValue(password)
                    .ClickLogin();

                // Wait for page to process
                Thread.Sleep(1500); // Give time for login to process

                // Step 6: Verify logged in successfully
                if (!homePage.IsLoggedInAsVisible()) // !false
                {
                    Console.WriteLine("[ERROR] Login failed - 'Logged in as' not visible");
                    return false;
                }
                Console.WriteLine("[SUCCESS] Logged in successfully");

                loginPage = homePage.LogoutAccount();

                // Step 8: Verify we're back on login page after logout
                if (!loginPage.IsOnLoginPage())
                {
                    Console.WriteLine("[ERROR] Logout failed - not on login page");
                    return false;
                }
                Console.WriteLine("[SUCCESS] Logout successful - back on login page");

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EXCEPTION] Login flow failed: {ex.Message}");
                return false;
            }
        }
    }
}