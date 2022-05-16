using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Project33.PageObjects
{
    internal class LoginPage
    {

        private IWebDriver driver3;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver3 = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        private IWebElement GetElement(By by)
        {
            IWebElement element;
            try
            {
                element = this.driver3.FindElement(by);
            }
            catch (Exception)
            {
                element = null;
            }
            return element;
        }

        public IWebElement UserName
        {
            get
            {
                return this.GetElement(By.Name("username"));
            }
        }
        public IWebElement Password
        {
            get
            {
                return this.GetElement(By.Name("password"));
            }
        }

        public IWebElement LogInButton
        {
            get
            {
                return this.GetElement(By.Name("login"));
            }
        }

        public IWebElement WelcomeMessage
        {
            get
            {
                return this.GetElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][3]/div[@class='col-sm-12 text-center']/h2"));
            }
        }
    }
}
