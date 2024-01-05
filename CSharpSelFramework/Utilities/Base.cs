using System;
using System.Configuration;
using System.IO;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.Page;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace CSharpSelFramework.Utilities
{
    public class Base
    {
        public ExtentReports extent;
        public ExtentTest test;
        String browserName;
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        //[OneTimeSetUp]
        public void SetUp()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name","Local host");
            extent.AddSystemInfo("Environemnt","QA");
        }
        
        [SetUp]
        public void StartBrowser()
        {
            //test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);
            driver.Value.Manage().Cookies.DeleteAllCookies();
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Value.Manage().Window.Maximize();
            // driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public void InitBrowser(String browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    driver.Value = new FirefoxDriver();
                    break;
                case "Chrome":
                    ChromeOptions chromeOptionsObj = new ChromeOptions();
                    chromeOptionsObj.AddArgument("--disable-infobars");
                    //chromeOptionsObj.AddArgument("--headless"); //to run in headless mode
                    driver.Value = new ChromeDriver(chromeOptionsObj);
                    break;
                case "Edge":
                    driver.Value = new EdgeDriver();
                    break;
            }
        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }
        
        [TearDown]
        public void AfterTest()
        {
            // var status = TestContext.CurrentContext.Result.Outcome.Status;
            // var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            //
            // DateTime time = DateTime.Now;
            // String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            //
            // if (status == TestStatus.Failed)
            // {
            //    // test.Fail("Test failed", captureScreenshot(driver.Value, fileName));
            //     test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
            // }
            // else if(status==TestStatus.Passed)
            // {
            //     
            // }
            driver.Value.Quit();
        }

        public static JsonReader getDataParser()
        {
           return new JsonReader();
        }

        // public Media captureScreenshot(IWebDriver driver, String scrrenShotName)
        // {
        //     ITakesScreenshot ts = (ITakesScreenshot)driver;
        //     var screenshot = ts.GetScreenshot().AsBase64EncodedString;
        //     return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, scrrenShotName).Build();
        // }

       // [OneTimeTearDown]
        public void OneTimeTearDown()
        {
           extent.Flush();
        }
    }
}