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
    }
}