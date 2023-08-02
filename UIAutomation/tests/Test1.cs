using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.utilities;
using UIAutomation.pageObjects;

namespace tests
{
    /*Below one is for package level parallel run   */
    [Parallelizable(ParallelScope.Self)]
    //at class level [Parallelizable(ParallelScope.Children)]
    internal class Test1:Base
    {
        [Test, Category("Regression")]
        //[TestCase("rahulshettyacademy", "learning")]
        [TestCaseSource("AddTestDataConfig")]
        [Parallelizable(ParallelScope.All)]
        public void EndToEndFlow(string username, string passeword)
        {

            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(getDriver());

            ProductsPage productsPage = 
                loginPage.validLogin(username, passeword);

            productsPage.waitForPageDisplay();

            IList<IWebElement> products = productsPage.getCards();

            foreach (IWebElement product in products)
            {
                if (
                    expectedProducts.Contains(product.FindElement(
                    productsPage.getCardTitle()).Text))
                {
                    //Click on cart
                    product.FindElement(productsPage.addToCartButton()).Click();
                }

            }
            
            Checkout checkoutPage = productsPage.getCheckout();

            IList<IWebElement> checkoutCarts =
                checkoutPage.getCheckoutCards();

            for (int i = 0; i < checkoutCarts.Count; i++)
            {

                actualProducts[i] = checkoutCarts[i].Text;

            }

            Assert.AreEqual(expectedProducts, actualProducts);

            PaymentPage paymentPage = checkoutPage.getCheckoutButton();


            paymentPage.getCountryDropdown()
                .SendKeys("ind");

            paymentPage.waitForCountrySelection();

            paymentPage.getCountryOptionElement();

            paymentPage.selectCheckboxOfPaymentPage();

            paymentPage.clickPurchaseButton();


            String confirmText = paymentPage.getSuccessMessage();

            StringAssert.Contains("Success", confirmText);

        }

        [Test, Category("Smoke")]
        public void LocatorIdentification()
        {
            driver.Value.FindElement(By.Id("username"))
                .SendKeys("rahulshettyacademy");
            driver.Value.FindElement(By.Id("username")).Clear();
            driver.Value.FindElement(By.Id("username"))
                .SendKeys("rahulshetty");
            driver.Value.FindElement(By.Id("password"))
                .SendKeys("123456");
            driver.Value
                .FindElement(By.CssSelector("input[value='Sign In']"))
                .Click();

            WebDriverWait wait = new WebDriverWait
                (driver.Value, TimeSpan.FromSeconds(5));

            wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions
                .TextToBePresentInElementValue(
                driver.Value
                .FindElement(By.CssSelector("input[value='Sign In']")),
                "Sign In"));

            String errorMessage = driver.Value.
                FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = driver.Value.FindElement
                (By.LinkText("Free Access to " +
                "InterviewQues/ResumeAssistance/Material"));

            //validate url of the linktext
            String hrefAttr = link.GetAttribute("href");
            String exptedURL =
                "https://rahulshettyacademy.com/documents-request";
            Assert.AreEqual(exptedURL, hrefAttr);

            //checkbox with xpath
            driver.Value.FindElement(
                By.XPath
                ("//div[@class='form-group'][5]/label/span/input"))
                .Click();

        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData("rahulshettyacademy", "learning");
        }
    }
}
