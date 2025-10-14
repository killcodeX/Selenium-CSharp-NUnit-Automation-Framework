using OpenQA.Selenium;
using AutomationExercise.Pages;
using AutomationExercise.TestData;

// Flow case 1

public class LoginFlow
{
    private IWebDriver driver;
    private int delay;

    public LoginFlow(IWebDriver driver, int delay = 20)
    {
        this.driver = driver;
        this.delay = delay;
    }

    public bool ExecuteLoginFlow(string email, string password)
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

            // Step 5: Check if login was successful
            bool isSuccessful = loginPage.IsLoginSuccessful();

            if (isSuccessful)
            {
                Console.WriteLine("[SUCCESS] Login successful - redirected from login page");
            }
            else
            {
                Console.WriteLine("[ERROR] Login failed");

                if (loginPage.IsErrorMessageDisplayed())
                {
                    string errorMsg = loginPage.GetErrorMessageText();
                    Console.WriteLine($"[ERROR] Error message displayed: {errorMsg}");
                }

                if (loginPage.IsOnLoginPage())
                {
                    Console.WriteLine("[ERROR] Still on login page after login attempt");
                }
            }

            return isSuccessful;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[EXCEPTION] Login flow failed: {ex.Message}");
            return false;
        }
    }
}