using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning;

public class Locators
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
    public void Test1()
    {
        driver.FindElement(By.Id("username")).SendKeys(("rahulshetty"));
        driver.FindElement(By.Id("password")).SendKeys(("123456"));
        //css selector - .text-info span:nth-child(1) input
        driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
        driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
        
        // Thread.Sleep(3000);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")),"Sign In"));
        String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
        TestContext.Progress.WriteLine(errorMessage);

        IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
        String hrefAttr = link.GetAttribute("href");
        String expectedVal = "https://rahulshettyacademy.com/documents-request";
        Assert.AreEqual(expectedVal,hrefAttr);
       
        //driver.Close();

    }
}