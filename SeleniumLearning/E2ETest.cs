using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumLearning
{
    class E2ETest
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
        public void EndToEndFlow()
        {

            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
            driver.FindElement(By.Id("username"))
                .SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password"))
                .SendKeys("learning");
            driver
                .FindElement(By.CssSelector("input[value='Sign In']"))
                .Click();

            WebDriverWait wait = new WebDriverWait
                (driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions
                .ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products =
                driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {
                if (
                    expectedProducts.Contains(product.FindElement(
                    By.CssSelector(".card-title a")).Text))
                {
                    //Click on cart
                    product.FindElement(By.CssSelector(
                        ".card-footer button")).Click();
                }
                
            }


            driver.FindElement(
                By.PartialLinkText("Checkout")).Click();

            IList<IWebElement> checkoutCarts =
                driver.FindElements(By.CssSelector("h4 a"));

            for (int i = 0; i < checkoutCarts.Count; i++) {

                actualProducts[i] = checkoutCarts[i].Text;
            
            }

            Assert.AreEqual(expectedProducts,actualProducts);

            driver.FindElement(
                By.CssSelector(".btn-success")).Click();
            driver.FindElement(By.Id("country"))
                .SendKeys("ind");

            wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions.ElementIsVisible(
                By.LinkText("India")));

            driver.FindElement(By.LinkText("India")).Click();

            driver.FindElement(By.CssSelector("" +
                "label[for*='checkbox2']")).Click();
            driver.FindElement(By.CssSelector("[value='" +
                "Purchase']")).Click();
            String confirmText=driver.FindElement(By.CssSelector("" +
                ".alert-success")).Text;

            StringAssert.Contains("Success",confirmText);


        }
    }
}
