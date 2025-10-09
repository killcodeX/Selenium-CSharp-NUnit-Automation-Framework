using System;
using OpenQA.Selenium;
using AutomationExercise.Pages;
using AutomationExercise.TestData;

namespace AutomationExercise.Flows
{
    public class RegistrationFlow
    {
        private IWebDriver driver;
        private HomePage homePage;
        private SignupPage signupPage;
        private RegisterPage registrationPage;

        public RegistrationFlow(IWebDriver driver, int delay = 20)
        {
            this.driver = driver;
            this.homePage = new HomePage(driver, delay);
            this.signupPage = new SignupPage(driver, delay);
            this.registrationPage = new RegisterPage(driver, delay);
        }
        public bool ExecuteCompleteRegistration(UserData userData)
        {
            // Steps 1-2: Navigate and verify home
            homePage.NavigateToHome();
            if (!homePage.IsHomePageVisible())
                return false;

            // Step 3: Click Signup/Login
            homePage.ClickSignupLogin();

            return false;
        }
    }
}
