using OpenQA.Selenium;
using AutomationExercise.Pages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutomationExercise.Flows
{
    public class ProductFlow
    {
        private IWebDriver driver;
        private int delay;
        private By product1AddCartBtn = By.CssSelector("a[data-product-id='1']");
        private By product2AddCartBtn = By.CssSelector("a[data-product-id='2']");

        public ProductFlow(IWebDriver driver, int delay = 20)
        {
            this.driver = driver;
            this.delay = delay;
        }
        /**
            ** Step 1: Verify that home page is visible successfully
            ** Step 2: Click on 'Products' button
            ** Step 3: Verify user is navigated to ALL PRODUCTS page successfully
            ** Step 4: The products list is visible
        **/
        public bool ExecuteVerifyAllProducts()
        {
            var homePage = new HomePage(driver, delay);
            homePage.NavigateToHome();

            if (!homePage.IsHomePageVisible())
            {
                Console.WriteLine("[ERROR] Home page is not visible");
                return false;
            }
            Console.WriteLine("[SUCCESS] Home page is visible");

            var allProductPage = homePage.NavigateToAllProducts();

            if (!allProductPage.IsAllProductsPageVisible())
            {
                Console.WriteLine("[ERROR] Home page is not visible");
                return false;
            }

            Console.WriteLine("[SUCCESS] All product page is visible");

            return true;
        }
        /**
            ** Step 1: Verify that home page is visible successfully
            ** Step 2: Click on 'Products' button
            ** Step 3: Verify user is navigated to ALL PRODUCTS page successfully
            ** Step 4: The products list is visible
            ** Step 5: Click on 'View Product' of first product
            ** Step 6: User is landed to product detail page
            ** Step 7: Verify that detail detail is visible: product name, category, price, availability, condition, brand
        **/
        public bool ExecuteVerifyAllProductsAndProductDetailPage()
        {
            var homePage = new HomePage(driver, delay);
            homePage.NavigateToHome();

            if (!homePage.IsHomePageVisible())
            {
                Console.WriteLine("[ERROR] Home page is not visible");
                return false;
            }
            Console.WriteLine("[SUCCESS] Home page is visible");

            var allProductPage = homePage.NavigateToAllProducts();

            if (!allProductPage.IsAllProductsPageVisible())
            {
                Console.WriteLine("[ERROR] Home page is not visible");
                return false;
            }

            Console.WriteLine("[SUCCESS] All product page is visible");

            var productPage = allProductPage.ClickFirstProductViewButton();

            if (!productPage.IsProductNameVisible())
            {
                Console.WriteLine("[ERROR] Product name is not visible");
                return false;
            }

            if (!productPage.IsPriceVisible())
            {
                Console.WriteLine("[ERROR] Product price is not visible");
                return false;
            }

            if (!productPage.IsCategoryVisible())
            {
                Console.WriteLine("[ERROR] Product category is not visible");
                return false;
            }

            if (!productPage.IsAvailabilityVisible())
            {
                Console.WriteLine("[ERROR] Product availability is not visible");
                return false;
            }

            if (!productPage.IsConditionVisible())
            {
                Console.WriteLine("[ERROR] Product condition is not visible");
                return false;
            }

            if (!productPage.IsBrandVisible())
            {
                Console.WriteLine("[ERROR] Product brand is not visible");
                return false;
            }

            Console.WriteLine("[SUCCESS] Product details are visible");

            Thread.Sleep(4000);

            return true;
        }
        /**
            ** Step 1: Verify that home page is visible successfully
            ** Step 2: Click on 'Products' button
            ** Step 3: Verify user is navigated to ALL PRODUCTS page successfully
            ** Step 4: Enter product name in search input and click search button
            ** Step 5: Verify 'SEARCHED PRODUCTS' is visible
            ** Step 6: Verify all the products related to search are visible
        **/
        public bool ExecuteSearchProduct(string value)
        {
            var homePage = new HomePage(driver, delay);
            homePage.NavigateToHome();

            if (!homePage.IsHomePageVisible())
            {
                Console.WriteLine("[ERROR] Home page is not visible");
                return false;
            }
            Console.WriteLine("[SUCCESS] Home page is visible");

            var allProductPage = homePage.NavigateToAllProducts();

            if (!allProductPage.IsAllProductsPageVisible())
            {
                Console.WriteLine("[ERROR] Home page is not visible");
                return false;
            }

            Console.WriteLine("[SUCCESS] All product page is visible");

            allProductPage.SearchProduct(value).ClickSearchButton();

            if (!allProductPage.IsSearchResultsVisible())
            {
                Console.WriteLine("[ERROR] Search product is not visible");
                return false;
            }

            Console.WriteLine("[SUCCESS] Search product page is visible");

            Thread.Sleep(4000);

            return true;
        }
        /**
            ** Step 1: Verify that home page is visible successfully
            ** Step 2: Click on 'Products' button
            ** Step 3: Verify user is navigated to ALL PRODUCTS page successfully
            ** Step 4: Hover over first product and click 'Add to cart'
            ** Step 5: Click 'Continue Shopping' button
            ** Step 6: Hover over second product and click 'Add to cart'
            ** Step 7: Click 'View Cart' button
            ** Step 8: Verify both products are added to Cart
            ** Step 9: Verify their prices, quantity and total price
        **/
        public bool ExecuteAddProductsInCart()
        {
            var homePage = new HomePage(driver, delay);
            homePage.NavigateToHome();

            if (!homePage.IsHomePageVisible())
            {
                Console.WriteLine("[ERROR] Home page is not visible");
                return false;
            }
            Console.WriteLine("[SUCCESS] Home page is visible");

            var allProductPage = homePage.NavigateToAllProducts();

            if (!allProductPage.IsAllProductsPageVisible())
            {
                Console.WriteLine("[ERROR] Home page is not visible");
                return false;
            }

            Console.WriteLine("[SUCCESS] All product page is visible");

            allProductPage.AddToCartProduct(product1AddCartBtn);
            allProductPage.AddToCartProduct(product2AddCartBtn);
            // giving time 
            Thread.Sleep(4000);

            var cartPage = allProductPage.NavigateToCartPage();

            if (!cartPage.IsProductPresentInCart())
            {
                Console.WriteLine("[ERROR] No product present in the cart");
                return false;
            }

            Console.WriteLine("[SUCCESS] Product are present in the cart");

            int product1Price = cartPage.GetProductPriceFromCart(0);
            int product1Quantity = cartPage.GetProductQuantityFromCart(0);
            int product1TotalPrice = cartPage.GetProductTotalPriceFromCart(0);

            Assert.AreEqual(product1Price, 500);
            Assert.AreEqual(product1Quantity, 1);
            Assert.AreEqual(product1TotalPrice, 500);

            int product2Price = cartPage.GetProductPriceFromCart(1);
            int product2Quantity = cartPage.GetProductQuantityFromCart(1);
            int product2TotalPrice = cartPage.GetProductTotalPriceFromCart(1);

            Assert.AreEqual(product2Price, 400);
            Assert.AreEqual(product2Quantity, 1);
            Assert.AreEqual(product2TotalPrice, 400);

            Thread.Sleep(4000);
            return true;
        }
    }
}