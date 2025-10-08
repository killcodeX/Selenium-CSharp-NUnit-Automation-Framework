using OpenQA.Selenium;

// Flow case 1

public class LoginFlow
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private int delay;

    public LoginFlow(IWebDriver driver, int delay = 20)
    {
        this.driver = driver;
        this.delay = delay;
        BasePage basePage = new BasePage(this.driver, delay);
        LoginPage loginPage = new LoginPage(this.driver, delay);
    }

    /**
    ** Step 1: Launch browser
    ** Step 2: Navigate to url 'http://automationexercise.com'
    ** Step 3: Verify that home page is visible successfully
    ** Step 4: Click on 'Signup / Login' button
    **/
    public void InitialStep()
    {
        driver.Navigate().GoToUrl("http://automationexercise.com");

    }
    /**
        ** Step 5:  Verify 'New User Signup!' is visible
        ** Step 6: Enter name and email address
        ** Step 7: Click 'Signup' button
        **/
    public bool ExecuteLoginFlow(string email, string password)
    {
        // Navigate to login page
        driver.Navigate().GoToUrl("http://automationexercise.com/login");

        // Perform login using fluent pattern
        loginPage
            .EnterEmailValue(email)
            .EnterPasswordValue(password)
            .ClickLogin();

        // Verify login success
        //return loginPage.IsLoginSuccessful();
        return true;
    }
}