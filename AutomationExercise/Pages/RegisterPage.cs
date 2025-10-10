using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class RegisterPage : BasePage
    {

        private By password = By.CssSelector("input[data-qa='password']");
        private By dobDay = By.CssSelector("select[data-qa='days']");
        private By dobMonth = By.CssSelector("select[data-qa='months']");
        private By dobYear = By.CssSelector("select[data-qa='years']");
        private By addressFname = By.CssSelector("input[data-qa='first_name']");
        private By addressLname = By.CssSelector("input[data-qa='last_name']");
        private By addressComp = By.CssSelector("input[data-qa='company']");
        private By addressLine = By.CssSelector("input[data-qa='address']");
        private By addressCon = By.CssSelector("select[data-qa='country']");
        private By addressState = By.CssSelector("input[data-qa='state']");
        private By addressCity = By.CssSelector("input[data-qa='city']");
        private By addressZipcode = By.CssSelector("input[data-qa='zipcode']");
        private By addressMobile = By.CssSelector("input[data-qa='mobile_number']");
        private By createAccBtn = By.CssSelector("button[data-qa='create-account']");


        public RegisterPage(IWebDriver driver, int delay) : base(driver, delay) { }

        public bool IsOnRegistrationPage()
        {
            //return IsElementVisible(By.Id("form"));
            return IsPageUrlCorrect("https://automationexercise.com/signup");
        }

        public RegisterPage ChooseTitle(By titleOpt)
        {
            SelectRadioOption(titleOpt);
            return this;
        }

        public RegisterPage ChoosePassword(string value)
        {
            Type(password, value);
            return this;
        }

        public RegisterPage SelectDayOfDateOfBirth(string value)
        {
            Dropdown(dobDay, value);
            return this;
        }

        public RegisterPage SelectMonthOfDateOfBirth(string value)
        {
            Dropdown(dobMonth, value);
            return this;
        }

        public RegisterPage SelectYearOfDateOfBirth(string value)
        {
            Dropdown(dobYear, value);
            return this;
        }

        public RegisterPage EnterAddressFname(string value)
        {
            Type(addressFname, value);
            return this;
        }

        public RegisterPage EnterAddressLname(string value)
        {
            Type(addressLname, value);
            return this;
        }

        public RegisterPage EnterAddressCompany(string value)
        {
            Type(addressComp, value);
            return this;
        }

        public RegisterPage EnterAddressLine(string value)
        {
            Type(addressLine, value);
            return this;
        }

        public RegisterPage EnterAddressCountry(string value)
        {
            Dropdown(addressCon, value);
            return this;
        }

        public RegisterPage EnterAddressState(string value)
        {
            Type(addressState, value);
            return this;
        }

        public RegisterPage EnterAddressCity(string value)
        {
            Type(addressCity, value);
            return this;
        }

        public RegisterPage EnterAddressZipcode(string value)
        {
            Type(addressZipcode, value);
            return this;
        }

        public RegisterPage EnterAddressMobileNumber(string value)
        {
            Type(addressMobile, value);
            return this;
        }

        public AccountCreatedPage ClickCreateAccount()
        {
            ClickElement(createAccBtn);
            return new AccountCreatedPage(webDriver, 10);
        }
    }
}

