using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace UIAutomation.pageObjects
{

    internal class ProductsPage
    {
        IWebDriver driver;
        By cardTitle = By.CssSelector(".card-title a");
        By cardButton = By.CssSelector(
                        ".card-footer button");
        public ProductsPage(IWebDriver driver) {
            this.driver=driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkout;


        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait
               (driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions
                .ElementIsVisible(By.PartialLinkText("Checkout")));

        }

        public By getCardTitle()
        {
            return cardTitle;

        }

        public By addToCartButton()
        {
            return cardButton;
        }

        public IList<IWebElement> getCards() {

            return cards;
        }

        public Checkout getCheckout()
        {
            checkout.Click();

            return new Checkout(this.driver);
        }
    }
}
