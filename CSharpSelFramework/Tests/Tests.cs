using System;
using System.Collections.Generic;
using System.Linq;
using CSharpSelFramework.PageObjects;
using CSharpSelFramework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpSelFramework
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class Tests : Base
    {
        
        // [TestCase("rahulshettyacademy","learning")]
        // [TestCase("rahulshetty","learning")]
        // [TestCase("rahulshettyacademy","learning")]
        
        //run all data sets of test method in parallel
        //run all test methods in one class parallel
        //run all test files in the entire project in parallel
        
        //run all the smoke/regression tests according to the category
        //[Test,TestCaseSource("AddTestDataConfig"),Category("Regression")]
        //dotnet test <cs proj file>
        //dotnet test <cs proj file> --filter TestCategory=Smoke 
        
        //[Test,TestCaseSource("AddTestDataConfig")]
        public void EndToEndFlow(String username, String password, String[] expectedProducts)
        {
            String[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productsPage = loginPage.validLogin(username,password);
            productsPage.waitForPageToLoad();
            IList<IWebElement> products = productsPage.getCards();

            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productsPage.getCardTitle()).Text))
                {
                    product.FindElement(productsPage.addToCartButton()).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(productsPage.getCardTitle()).Text);
            }
            CheckoutPage checkoutPage = productsPage.checkout();

            //verify the elements added in the checkout page
            IList<IWebElement> checkoutCards = checkoutPage.getCheckoutCards();
            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);
            
            //complete the checkout process and verify the success message
            ConfirmationPage purchasePage = checkoutPage.checkOut();
            bool isSuccessMsgDisplayed = purchasePage.enterPurchaseInfo();
           
            Assert.True(isSuccessMsgDisplayed,"Success message is not displayed");
        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"),getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username"),getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
        }

        [Parallelizable(ParallelScope.Children)]
        [Test]
        public void Test2()
        {
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine("2nd test executed");
        }
        [Parallelizable(ParallelScope.Children)]
        [Test]
        public void Test3()
        {
            driver.Value.Url = "https://google.com";
            TestContext.Progress.WriteLine("3rd test executed");
        }
    }
}