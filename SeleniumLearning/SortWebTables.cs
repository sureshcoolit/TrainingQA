using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning;

public class SortWebTables
{
    private IWebDriver driver;
    
    [SetUp]
    public void StartBrowser()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Manage().Window.Maximize();
        driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
    }

    [Test]
    public void sortTable()
    {
        SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
        dropdown.SelectByValue("20");
        //Step1 - Get all the first column veggie names into ArrayList
        IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));
        
        //Step2 - Get all the veggie names into ArrayList
        ArrayList a = new ArrayList();
        foreach (IWebElement veggie in veggies)
        {
            a.Add(veggie.Text);
        }
        
        //Step3 - Print the array list before sort & Sort the array list & Print the array list
        TestContext.Progress.WriteLine("Before sorting the arraylist");
        foreach (String s in a)
        {
            TestContext.Progress.WriteLine(s);
        }
        
        a.Sort();
        TestContext.Progress.WriteLine("After sorting the arraylist");
        
        foreach (String s in a)
        {
            TestContext.Progress.WriteLine(s);
        }
        
        //Step4 - Go and click the column for sorting 
        //css - th[aria-label*="fruit name"] here * means contains
        //xpath - //th[contains(@aria-label,"fruit")]
        driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();
        
        //Step5 - Now get the veggie names into new array list and compare the sorted veggies
        IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));
        
        ArrayList b = new ArrayList();
        foreach (IWebElement veggie in sortedVeggies)
        {
            b.Add(veggie.Text);
        }
        
        Assert.AreEqual(a,b);
            

    }
}