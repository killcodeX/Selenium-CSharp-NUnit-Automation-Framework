using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class ProductPage : BasePage
    {
        // Use CSS for simple structure-based selectors
        private By productName = By.CssSelector("div.product-information h2");
        private By price = By.CssSelector("div.product-information span span");

        // Use XPath when you need text matching
        private By category = By.XPath("//div[@class='product-information']//p[contains(text(), 'Category:')]");
        private By availability = By.XPath("//div[@class='product-information']//p[contains(., 'Availability:')]");
        private By condition = By.XPath("//div[@class='product-information']//p[contains(., 'Condition:')]");
        private By brand = By.XPath("//div[@class='product-information']//p[contains(., 'Brand:')]");
        public ProductPage(IWebDriver driver, int delay) : base(driver, delay) { }

        public bool IsProductNameVisible()
        {
            return IsElementVisible(productName);
        }

        public bool IsPriceVisible()
        {
            return IsElementVisible(price);
        }

        public bool IsCategoryVisible()
        {
            return IsElementVisible(category);
        }

        public bool IsAvailabilityVisible()
        {
            return IsElementVisible(availability);
        }

        public bool IsConditionVisible()
        {
            return IsElementVisible(condition);
        }

        public bool IsBrandVisible()
        {
            return IsElementVisible(brand);
        }
    }
}

