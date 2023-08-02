using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.pageObjects
{
    internal class PaymentPage
    {
        IWebDriver driver;
        By dropdownOption = By.LinkText("India");
        public PaymentPage(IWebDriver driver) { 
        
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement countryDropdown;
        public IWebElement getCountryDropdown() { return countryDropdown; }


        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement countryOptionElement;
        

        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2']")]
        private IWebElement checkbox;


        [FindsBy(How = How.CssSelector, Using = "[value='" +
                "Purchase']")]
        private IWebElement purchaseButton;


        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement successMessageElement;


        public void waitForCountrySelection()
        {
            WebDriverWait wait = new WebDriverWait
               (driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions
                .ElementIsVisible(dropdownOption));

        }

        public void getCountryOptionElement() {

            countryOptionElement.Click();
        }

        public void selectCheckboxOfPaymentPage()
        {
            checkbox.Click();
        }

        public void clickPurchaseButton() { 
        
            purchaseButton.Click();
        }

        public string getSuccessMessage() {

            return successMessageElement.Text;
        }
    }
}
