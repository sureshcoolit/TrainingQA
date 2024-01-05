using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }
        
        //PageObject Factory / Page Factory pattern of declaring locators
        //driver.FindElement(By.Id("username")).SendKeys(("rahulshettyacademy"));

        [FindsBy(How = How.Id, Using = "username")] 
        private IWebElement username;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkbox;
        
        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signInButton;

        public ProductsPage validLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkbox.Click();
            signInButton.Click();
            return new ProductsPage(driver);
        }

        //To expose the private username in any class, we can write ii in a public method and use in another class
        //This is called encapsulation
        public IWebElement getUserName()
        {
            return username;
        }
        
        
        
    }
}