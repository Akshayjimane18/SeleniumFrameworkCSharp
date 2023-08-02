using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.pageObjects
{
    internal class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver) { 
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        //pagefacatory
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;
        public IWebElement getUsername() { return username; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;
        public IWebElement getPassword() { return password; }
        

        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signIn;
        public IWebElement getSignIn() {  return signIn; }

        public ProductsPage validLogin(string username, string password)
        {
            getUsername().SendKeys(username);
            getPassword().SendKeys(password);
            getSignIn().Click();
            return new ProductsPage(this.driver);
        }

    }
}
