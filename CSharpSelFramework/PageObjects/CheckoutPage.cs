using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    public class CheckoutPage
    {
        private IWebDriver driver;
        
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutButton;

        public IList<IWebElement> getCheckoutCards()
        {
            return checkoutCards;
        }

        public ConfirmationPage checkOut()
        {
            checkoutButton.Click();
            return new ConfirmationPage(driver);
        }

    }
}