using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras.WaitHelpers;

namespace AutomationExercise.Pages
{
    public class AllProductsPage : BasePage
    {
        private By productPageTitle = By.XPath("//h2[contains(text(), 'All Products')]");
        private By searchResultTitle = By.XPath("//h2[contains(text(), 'Searched Products')]");
        // Locator for all "View Product" buttons
        private By allViewProductButtons = By.CssSelector("a[href*='/product_details/']");
        private By searchProductInput = By.Id("search_product");
        private By searchProductButton = By.Id("submit_search");
        private By cartButton = By.CssSelector("a[href*='view_cart']");
        public AllProductsPage(IWebDriver driver, int delay) : base(driver, delay) { }

        public bool IsAllProductsPageVisible()
        {
            return IsElementVisible(productPageTitle);
        }

        public bool IsSearchResultsVisible()
        {
            // Wait until either the "Searched Products" heading or updated results appear
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(searchResultTitle));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public ProductPage ClickFirstProductViewButton()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var productList = wait.Until(d => d.FindElements(allViewProductButtons));
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

            return new ProductPage(webDriver, 10);
        }

        public AllProductsPage SearchProduct(string value)
        {
            Type(searchProductInput, value);
            return this;
        }

        public AllProductsPage ClickSearchButton()
        {
            ClickElement(searchProductButton);
            // Wait for the URL to include `search=`
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url.Contains("search="));
            return this;
        }

        public IList<IWebElement> FetchAllElement()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            // Wait and return the list of elements
            return wait.Until(d =>
            {
                var elements = d.FindElements(allViewProductButtons);
                return elements.Count > 0 ? elements : null;
            });
        }

        public AllProductsPage AddToCartProduct(By Product)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            HoverAndClick(Product);

            // Wait for the popup/modal to be visible
            IWebElement popup = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[@class='modal-content']")
            ));

            // Click on Continue Shopping button
            webDriver.FindElement(By.XPath("//button[text()='Continue Shopping']")).Click();

            return this;
        }

        public CartPage NavigateToCartPage()
        {
            ClickElement(cartButton);
            return new CartPage(webDriver, 10);
        }
    }
}