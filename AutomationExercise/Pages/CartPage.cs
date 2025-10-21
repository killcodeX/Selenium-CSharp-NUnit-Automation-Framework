using Microsoft.CodeAnalysis.CSharp.Syntax;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationExercise.Pages
{
    public class CartPage : BasePage
    {
        private By cartProducts = By.CssSelector("#cart_info_table tbody tr");
        private By checkoutBtn = By.CssSelector(".check_out");
        public CartPage(IWebDriver driver, int delay) : base(driver, delay) { }

        public bool IsProductPresentInCart()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var productList = wait.Until(d => d.FindElements(cartProducts));
            return productList.Count > 0;
        }

        public int GetProductPriceFromCart(int productIndex)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var productList = wait.Until(d => d.FindElements(cartProducts));

            var product = productList[productIndex];
            var priceElement = product.FindElement(By.CssSelector(".cart_price"));

            // Use Replace() not Remove()
            string priceText = priceElement.Text.Replace("Rs. ", "").Trim();

            return int.Parse(priceText);
        }

        public int GetProductQuantityFromCart(int productIndex)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var productList = wait.Until(d => d.FindElements(cartProducts));

            var product = productList[productIndex];
            var priceElement = product.FindElement(By.CssSelector(".cart_quantity"));

            // Use Replace() not Remove()
            string priceText = priceElement.Text.Trim();

            return int.Parse(priceText);
        }

        public int GetProductTotalPriceFromCart(int productIndex)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var productList = wait.Until(d => d.FindElements(cartProducts));

            var product = productList[productIndex];
            var priceElement = product.FindElement(By.CssSelector(".cart_total_price"));

            // Use Replace() not Remove()
            string priceText = priceElement.Text.Replace("Rs. ", "").Trim();

            return int.Parse(priceText);
        }
    }
}