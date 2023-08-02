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
using OpenQA.Selenium.Interactions;

namespace SeleniumLearning
{
    internal class AlertActionsSuggestive
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
                "https://rahulshettyacademy.com/AutomationPractice/";
        }

        [Test]
        public void test_alert()
        {
            String name = "Rahul";
            driver.FindElement(
                By.CssSelector("#name"))
                .SendKeys(name);
            driver.FindElement(By.CssSelector(
                "input[onclick='displayConfirm()']")).Click();
            String alertText = driver.SwitchTo().Alert().Text;

            driver.SwitchTo().Alert().Accept();

            StringAssert.Contains(name, alertText);


        }

        [Test]
        public void test_AutoSuggestedDropdown() {

            driver.FindElement(By.Id("autocomplete"))
                .SendKeys("ind");

            Thread.Sleep(3000);

            IList<IWebElement> options =
                driver.FindElements(By.CssSelector(
                    ".ui-menu-item div"));

            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                    break;  
                }
            }

            TestContext.WriteLine(driver.FindElement(
                By.Id("autocomplete")).GetAttribute(
                "value"));

               
        }

        [Test]
        public void test_Actions() {

            driver.Url =
                "https://rahulshettyacademy.com";
            Actions a = new Actions(driver);
            a.MoveToElement(driver.
                FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();

            driver.FindElement
                (By.XPath("//ul[@class='dropdown-menu']/li[1]/a")).Click();

        }

        [Test]
        public void frames()
        {
            IWebElement framescroll =
                driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0]" +
                ".scrollIntoView(true);",framescroll);
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement
                (By.LinkText("All Access Plan")).Click();
            TestContext.Progress.WriteLine(driver.FindElement(
                By.CssSelector("h1")).Text);
            driver.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.FindElement(
                By.CssSelector("h1")).Text);

        }
    }
}
