using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Program
    {
        IWebDriver driver;
        [SetUp]
        public void Setup() {
            TestContext.Progress.WriteLine("Setup method execution");
            new WebDriverManager.
                DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("This is test 1");
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
            
            
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("This is test 2");
        }

        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("Tear down method");
        }
    }
}
