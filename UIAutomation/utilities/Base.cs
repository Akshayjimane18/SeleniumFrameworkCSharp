using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using System.Threading;
using AventStack.ExtentReports.Reporter;
using System.IO;
using AventStack.ExtentReports;
using ICSharpCode.SharpZipLib.Zip;

namespace UIAutomation.utilities
{
    internal class Base
    {

        /*
         * For Reporting purpose onetimesetup is there which will execute once
         */
        public ExtentReports extent;
        public ExtentTest test;
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            String reportPath =projectDirectory + "\\index.html";
            var htmlReporter = new  ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
        }
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [SetUp]
        public void StartBrowser()
        {

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            String browserName = ConfigurationManager.AppSettings["browser"];

            /*
             * From Terminal if you want to run then
             * browserName=TestContext.Parameters["browserName"];
             * you can add if condition for null check if it's not passed
             * from terminal then accept the value from App.Config
             */
            InitBrowser("Chrome");
            driver.Value.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url =
                "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)
        {

            switch (browserName)
            {
                case "Firefox":

                    new WebDriverManager.
                DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;

                case "Chrome":

                    new WebDriverManager.
                DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;

                case "Edge":

                    new WebDriverManager.
                DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;

            }

        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {

                test.Fail("Test Failed");
                test.Fail((AventStack.ExtentReports.MarkupUtils.IMarkup)captureScreenshot(driver.Value, fileName));

            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                

            }
            extent.Flush();
            driver.Value.Quit();
        }

        public MediaEntityBuilder captureScreenshot(IWebDriver driver,String screenshotName) {

            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            var screenshot = takesScreenshot.GetScreenshot().AsBase64EncodedString;

           return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotName, screenshot);
        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }
    }
}
