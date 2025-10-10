using System;
using OpenQA.Selenium;
using AutomationExercise.Pages;
using AutomationExercise.TestData;

namespace AutomationExercise.Flows
{
    public class RegistrationFlow
    {
        private By titleOpt = By.CssSelector("input[id='id_gender1']");
        private IWebDriver driver;
        private int delay;
        public RegistrationFlow(IWebDriver driver, int delay = 20)
        {
            this.driver = driver;
            this.delay = delay;
        }

        public bool ExecuteCompleteRegistration(UserData userData)
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

            // Step 3: Click Signup/Login - This returns SignupPage
            var signupPage = homePage.ClickSignupLogin();

            // Verify we're on signup page
            if (!signupPage.IsOnSignupPage())
            {
                Console.WriteLine("[ERROR] Not on signup page");
                return false;
            }
            Console.WriteLine("[SUCCESS] On signup page");

            // Step 4-5: Enter name and email & Click Signup - This returns RegisterPage
            var registerPage = signupPage
                .EnterNameValue(userData.FirstName)
                .EnterEmailValue(userData.Email)
                .ClickSignup(); // ✅ Returns RegisterPage

            // Step 6: Verify that 'ENTER ACCOUNT INFORMATION' is visible
            // FIXED: Logic was inverted (if true, return false was wrong)
            if (!registerPage.IsOnRegistrationPage())
            {
                Console.WriteLine("[ERROR] Registration page not visible");
                return false;
            }
            Console.WriteLine("[SUCCESS] Registration page is visible");

            // Step 7: Fill registration details
            var accountCreatedPage = registerPage
                .ChooseTitle(titleOpt)
                .EnterAddressFname(userData.FirstName)
                .EnterAddressLname(userData.LastName)
                .ChoosePassword(userData.Password)
                .SelectDayOfDateOfBirth(userData.Day)
                .SelectMonthOfDateOfBirth(userData.Month)
                .SelectYearOfDateOfBirth(userData.Year)
                .EnterAddressCompany(userData.Company)
                .EnterAddressLine(userData.Address)
                .EnterAddressCountry(userData.Country)
                .EnterAddressState(userData.State)
                .EnterAddressCity(userData.City)
                .EnterAddressZipcode(userData.Zipcode)
                .EnterAddressMobileNumber(userData.MobileNumber)
                .ClickCreateAccount(); // ✅ Returns AccountCreatedPage

            // Step 8: Verify account created
            if (!accountCreatedPage.IsAccountCreated())
            {
                Console.WriteLine("[ERROR] Account creation failed");
                return false;
            }

            accountCreatedPage.ClickContinue();
            Console.WriteLine("[SUCCESS] Account created successfully!");

            return true; // ✅ Return true on success
        }
    }
}
