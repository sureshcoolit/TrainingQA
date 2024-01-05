using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning;

public class SeleniumFirst
{
    private IWebDriver driver;
    
    [SetUp]
    public void StartBrowser()
    {
        //We need to install the WebDriverManager package
        //WebDriverManager is used to download the chromedriver.exe automatically according to your browser version
        //From .Net 4.6 or higher version, this WebDriverManager is not needed, SeleniumDriverManager will handle automatically called
        //chrome- chromedriver.exe
        //firefox - geckodriver
        //Microsoft Edge - edgedriver.exe
        
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
        //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
        driver = new ChromeDriver();
        //driver = new FirefoxDriver();
        //driver = new EdgeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1()
    {
        driver.Url = "https://rahulshettyacademy.com/#/index";
        TestContext.Progress.WriteLine(driver.Url);
        TestContext.Progress.WriteLine(driver.Title);
        driver.Close(); //will close the current window
        //driver.Quit();// will close all the windows opened by automation tests
    }
}