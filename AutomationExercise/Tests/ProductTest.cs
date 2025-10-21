using OpenQA.Selenium;
using NUnit.Framework;
using AutomationExercise.Flows;
using AutomationExercise.Utils;


namespace AutomationExercise.Tests
{
    [TestFixture]
    [Order(3)]
    public class ProductTest : BaseTest
    {
        private ProductFlow productFlow;
        [SetUp]
        public void TestSetup()
        {
            productFlow = new ProductFlow(driver, 10);
            ExtentTestManager.LogInfo("All Products flow initialized");
        }
        /**
        [Test, Order(1), Category("Smoke")]
        [Description("Verify all product page")]
        public void TC01_VerifyAllProductAndProductDetailPage()
        {
            ExtentTestManager.LogInfo("=== Test Steps ===");
            ExtentTestManager.LogInfo("Step 1: Navigate to home page");
            ExtentTestManager.LogInfo("Step 2: Verify that home page is visible successfully");
            ExtentTestManager.LogInfo("Step 3: Click on 'Products' button");
            ExtentTestManager.LogInfo("Step 3: Verify user is navigated to ALL PRODUCTS page successfully");
            ExtentTestManager.LogInfo("Step 3: The products list is visible");
            bool result = productFlow.ExecuteVerifyAllProductsAndProductDetailPage();

            // Assert and log result
            if (result)
            {
                ExtentTestManager.LogPass("✓ All Product page visible");
            }
            else
            {
                ExtentTestManager.LogFail("✗ All Product page not visible");
            }

            Assert.IsTrue(result, "All Product page visible");
        }

        [Test, Order(2), Category("Smoke")]
        [Description("Verify search product page")]
        public void TC02_VerifySearchProduct()
        {
            ExtentTestManager.LogInfo("=== Test Steps ===");
            ExtentTestManager.LogInfo("Step 1: Navigate to home page");
            ExtentTestManager.LogInfo("Step 2: Verify that home page is visible successfully");
            ExtentTestManager.LogInfo("Step 3: Click on 'Products' button");
            ExtentTestManager.LogInfo("Step 4: Verify user is navigated to ALL PRODUCTS page successfully");
            ExtentTestManager.LogInfo("Step 5: Enter product name in search input and click search button");
            ExtentTestManager.LogInfo("Step 6: Verify 'SEARCHED PRODUCTS' is visible");
            ExtentTestManager.LogInfo("Step 7: Verify all the products related to search are visible");

            bool result = productFlow.ExecuteSearchProduct("Men Tshirt");

            // Assert and log result
            if (result)
            {
                ExtentTestManager.LogPass("✓ Searched product visible");
            }
            else
            {
                ExtentTestManager.LogFail("✗ Searched product not visible");
            }

            Assert.IsTrue(result, "Searched product visible");
        }
        **/
        [Test, Order(3), Category("Smoke")]
        [Description("Add Products in Cart")]
        public void TC03_AddToProduct()
        {
            ExtentTestManager.LogInfo("=== Test Steps ===");
            ExtentTestManager.LogInfo("Step 1: Navigate to home page");
            ExtentTestManager.LogInfo("Step 2: Verify that home page is visible successfully");
            ExtentTestManager.LogInfo("Step 3: Click on 'Products' button");
            ExtentTestManager.LogInfo("Step 4: Verify user is navigated to ALL PRODUCTS page successfully");
            ExtentTestManager.LogInfo("Step 5: Hover over first product and click 'Add to cart'");
            ExtentTestManager.LogInfo("Step 6: Click 'Continue Shopping' button");
            ExtentTestManager.LogInfo("Step 7: Hover over second product and click 'Add to cart'");
            ExtentTestManager.LogInfo("Step 8: Click 'View Cart' button");
            ExtentTestManager.LogInfo("Step 9: Verify both products are added to Cart");
            ExtentTestManager.LogInfo("Step 10: Verify their prices, quantity and total price");

            bool result = productFlow.ExecuteAddProductsInCart();

            // Assert and log result
            if (result)
            {
                ExtentTestManager.LogPass("✓ Searched product visible");
            }
            else
            {
                ExtentTestManager.LogFail("✗ Searched product not visible");
            }

            Assert.IsTrue(result, "Searched product visible");
        }
    }
}