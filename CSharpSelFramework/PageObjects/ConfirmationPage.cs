using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    public class ConfirmationPage
    {
        private IWebDriver driver;
        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement txtCountry;
        
        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement country;
        
        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2']")]
        private IWebElement termsCheckbox;
        
        [FindsBy(How = How.CssSelector, Using = "input[value='Purchase']")]
        private IWebElement purchaseButton;
        
        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement successMsg;

        public bool enterPurchaseInfo()
        {
            bool isSuccessMsgDisplayed;
            txtCountry.SendKeys("ind");
            Thread.Sleep(3000);
            country.Click();
            termsCheckbox.Click();
            purchaseButton.Click();
            isSuccessMsgDisplayed = successMsg.Displayed;
            return isSuccessMsgDisplayed;
        }
  
    }
}