using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationExercise.Pages
{
    public class AllProductsPage : BasePage
    {
        private By productPageTitle = By.XPath("//h2[contains(text(), 'All Products')]");
        // Locator for all "View Product" buttons
        private By allViewProductButtons = By.CssSelector("a[href*='/product_details/']");
        public AllProductsPage(IWebDriver driver, int delay) : base(driver, delay) { }

        public bool IsAllProductsPageVisible()
        {
            return IsElementVisible(productPageTitle);
        }

        public void ClickFirstProductViewButton()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var productList = wait.Until(d => d.FindElements(allViewProductButtons));
            Console.WriteLine($"✅ Clicked on first product's View Product button ---{productList}");
            //checking product
            if (productList.Count > 0)
            {
                // Click the first one
                wait.Until(ExpectedConditions.ElementToBeClickable(productList[0]));
                productList[0].Click();
                Console.WriteLine("✅ Clicked on first product's View Product button");
            }
            else
            {
                throw new NoSuchElementException("No View Product buttons found");
            }
        }
    }
}