using System;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace AutomationExercise.Pages
{


    public class AccountCreatedPage : BasePage
    {
        // Locators - must be inside the class
        private By successMessage = By.CssSelector("h2[data-qa='account-created']");
        private By continueButton = By.CssSelector("a[data-qa='continue-button']");

        public AccountCreatedPage(IWebDriver driver, int delay) : base(driver, delay) { }

        public bool IsAccountCreated()
        {
            // Option 1: Check by element visibility
            return IsElementVisible(successMessage);

            // Option 2: Check by URL
            // return IsPageUrlCorrect("/account_created");
        }

        // Check if on account created page
        public bool IsOnAccountCreatedPage()
        {
            return IsPageUrlCorrect("account_created");
        }

        // Get success message text
        public string GetSuccessMessage()
        {
            try
            {
                var element = wait.Until(ExpectedConditions.ElementIsVisible(successMessage));
                return element.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Could not get success message: {ex.Message}");
                return string.Empty;
            }
        }

        // Click continue button to go to home page
        public HomePage ClickContinue()
        {
            ClickElement(continueButton);
            return new HomePage(webDriver, 10);
        }

    }
}