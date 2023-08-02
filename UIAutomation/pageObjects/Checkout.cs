using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.pageObjects
{
    internal class Checkout
    {
        IWebDriver driver;
        public Checkout(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;
        public IList<IWebElement> getCheckoutCards() { return checkoutCards; }


        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutButton;
        public PaymentPage getCheckoutButton() { 
            checkoutButton.Click();
            return new PaymentPage(this.driver);
        }
    }
}
