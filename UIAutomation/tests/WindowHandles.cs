using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using UIAutomation.utilities;

namespace tests
{
    [Parallelizable(ParallelScope.Self)]
    internal class WindowHandles:Base
    {
        

        [Test]
        public void WindowHandle()
        {
            String email="mentor@rahulshettyacademy.com";
            String parentWindow = driver.Value.CurrentWindowHandle;
            driver.Value.FindElement(
                By.ClassName("blinkingText")).Click();

            Assert.AreEqual(2, driver.Value.WindowHandles.Count);

            String chilWindowName = driver.Value.WindowHandles[1];
            driver.Value.SwitchTo().Window(chilWindowName);
            TestContext.Progress.WriteLine(
                driver.Value.FindElement(
                    By.CssSelector(".red")).Text);

            String text = driver.Value.FindElement(
                    By.CssSelector(".red")).Text;

            
            String[] splittedText = text.Split();

            String[] trimmedString = splittedText[4].Trim()
                .Split(' ');

            Assert.AreEqual(email, trimmedString[0]);

            driver.Value.SwitchTo().Window(parentWindow);

            driver.Value.FindElement(By.Id("username")).
                SendKeys(trimmedString[0]);


        }

    }
}
