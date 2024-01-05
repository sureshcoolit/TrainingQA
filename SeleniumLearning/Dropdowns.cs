using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning;

public class Dropdowns
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
    public void selectDropdownElements()
    {
        IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
        SelectElement element = new SelectElement(dropdown);
        element.SelectByIndex(2);
        element.SelectByText("Teacher");
        element.SelectByValue("consult");
    }

    [Test]
    public void selectRadioButton()
    {
        IList<IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio']"));

        foreach (IWebElement radioButton in rdos)
        {
            if (radioButton.GetAttribute("value").Contains("user"))
            {
                radioButton.Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(driver.FindElement(By.Id("okayBtn"))));
                driver.FindElement(By.Id("okayBtn")).Click();
                // bool result = driver.FindElement(By.Id("okayBtn")).Selected;
                // Assert.That(result, Is.True);
            }
        }
    }
    
}