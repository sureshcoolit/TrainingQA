using System.ComponentModel.DataAnnotations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumLearning;

public class AlertsConfirmationsActionsAutoSuggestions
{
    private IWebDriver driver;
    
    [SetUp]
    public void StartBrowser()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Manage().Window.Maximize();
        driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
    }

    //[Test]
    public void testAlert()
    {
        String name = "Neelima";
        driver.FindElement(By.CssSelector("#name")).SendKeys(name);
        driver.FindElement(By.CssSelector("input[onclick*=Confirm]")).Click();
        String alertMsg = driver.SwitchTo().Alert().Text;
        driver.SwitchTo().Alert().Accept();
        //driver.SwitchTo().Alert().Dismiss();
        //driver.SwitchTo().Alert().SendKeys("sdfdsf");
        StringAssert.Contains(name,alertMsg);
    }

    //[Test]
    public void autoSuggestionDropdowns()
    {
        driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
        Thread.Sleep(3000);
        IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
        foreach (IWebElement option in options)
        {
            if (option.Text.Equals("India"))
            {
                option.Click();
                break;
            }
        }
        
        //GetAttribute is used when you wanted to get a textbox value at run time
        TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
    }

    //[Test]
    public void testActionsMouseOverAndClick()
    {
        //hover the mouse on the menu tab and click on "About us" option
        driver.Url = "https://rahulshettyacademy.com";
        Actions action = new Actions(driver);
        action.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
        //driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a")).Click();
        action.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();
    }
    
    //[Test]
    public void testActionsDragAndDrop()
    {
        driver.Url = "https://demoqa.com/droppable/";
        Actions action = new Actions(driver);
        action.DragAndDrop(driver.FindElement(By.Id("draggable")),driver.FindElement(By.Id("droppable"))).Perform();
        
    }

    //[Test]
    public void testIFrames()
    {
        driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        
        //For scrolling the page down use IJavaScriptExecutor
        IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);",frameScroll);
            
        driver.SwitchTo().Frame("courses-iframe");
        driver.FindElement(By.LinkText("All Access Plan")).Click();
        TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
        driver.SwitchTo().DefaultContent();
        TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
    }
    
    [Test]
    public void testMultipleWindows()
    {
        driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        
        //switching parent & child windows
        String parentWindow = driver.CurrentWindowHandle;
        driver.FindElement(By.CssSelector(".blinkingText")).Click();
        Assert.AreEqual(2,driver.WindowHandles.Count);
        String childWindow = driver.WindowHandles[1];
        driver.SwitchTo().Window(childWindow);
        TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text); 
        //Please email us at mentor@rahulshettyacademy.com with below template to receive response
        //we need to extract the email int he above text and print it

        String email = "mentor@rahulshettyacademy.com";
        String text = driver.FindElement(By.CssSelector(".red")).Text;
        String[] splittedText = text.Split("at");
        String[] trimmedText = splittedText[1].Trim().Split(" ");
        Assert.AreEqual(email,trimmedText[0]);

        driver.SwitchTo().Window(parentWindow);
        driver.FindElement(By.Id("username")).SendKeys(trimmedText[0]);
    }
}