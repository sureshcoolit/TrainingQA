using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning;

public class E2ETest
{
    private IWebDriver driver;
    
    [SetUp]
    public void StartBrowser()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Manage().Window.Maximize();
        driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
    }

    [Test]
    public void EndToEndFlow()
    {
        driver.FindElement(By.Id("username")).SendKeys(("rahulshettyacademy"));
        driver.FindElement(By.Id("password")).SendKeys(("learning"));
        driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
        driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

        String[] expectedProducts = { "iphone X", "Blackberry" };
        IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
        foreach (IWebElement product in products)
        {
            if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
            {
                product.FindElement(By.CssSelector(".card-footer button")).Click();
            }
            TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
        }
        driver.FindElement(By.PartialLinkText("Checkout")).Click();

        //verify the elements added in the checkout page
        IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));
        String[] actualProducts = new string[2];
        for (int i = 0; i < checkoutCards.Count; i++)
        {
            actualProducts[i] = checkoutCards[i].Text;
        }
        Assert.AreEqual(expectedProducts, actualProducts);
        
        //complete the checkout process and verify the success message
        driver.FindElement(By.CssSelector(".btn-success")).Click();
        driver.FindElement(By.Id("country")).SendKeys("ind");
        
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        driver.FindElement(By.LinkText("India")).Click();
        
        driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
        driver.FindElement(By.CssSelector("input[value='Purchase']")).Click();

        String successMsg = driver.FindElement(By.CssSelector(".alert-success")).Text;
        StringAssert.Contains("Success",successMsg);
    }
}