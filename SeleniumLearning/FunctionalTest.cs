﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using AngleSharp.Html.Dom;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace SeleniumLearning
{
    internal class FunctionalTest
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
        public void dropdown()
        {

            IWebElement dropdown = driver.FindElement(
                By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");

            IList<IWebElement> rdos = driver.
                FindElements(By.CssSelector(
                    "input[type='radio']"));

            foreach (IWebElement radioButton in rdos)
            {
                if (rdos[1].GetAttribute("value").Equals("user"))
                {

                    radioButton.Click();

                }
            }

            WebDriverWait wait = new WebDriverWait
                (driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions
                .ElementToBeClickable(By.Id("okayBtn")));

            driver.FindElement(By.Id("okayBtn")).Click();

            Boolean result = driver.
                FindElement(By.Id("usertype")).Selected;

            //Assert.That(result, Is.True);
        }
    }
}
