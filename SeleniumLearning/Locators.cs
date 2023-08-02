using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    internal class Locators
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.
                DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url =
                "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void LocatorIdentification()
        {
            driver.FindElement(By.Id("username"))
                .SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username"))
                .SendKeys("rahulshetty");
            driver.FindElement(By.Id("password"))
                .SendKeys("123456");
            driver
                .FindElement(By.CssSelector("input[value='Sign In']"))
                .Click();

            WebDriverWait wait = new WebDriverWait
                (driver, TimeSpan.FromSeconds(5));

            wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions
                .TextToBePresentInElementValue(
                driver
                .FindElement(By.CssSelector("input[value='Sign In']")),
                "Sign In"));

            String errorMessage = driver.
                FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = driver.FindElement
                (By.LinkText("Free Access to " +
                "InterviewQues/ResumeAssistance/Material"));

            //validate url of the linktext
            String hrefAttr = link.GetAttribute("href");
            String exptedURL =
                "https://rahulshettyacademy.com/documents-request";
            Assert.AreEqual(exptedURL, hrefAttr);

            //checkbox with xpath
            driver.FindElement(
                By.XPath
                ("//div[@class='form-group'][5]/label/span/input"))
                .Click();

        }
    }
}
