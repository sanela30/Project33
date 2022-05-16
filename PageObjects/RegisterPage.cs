using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Project33.PageObjects
{
    internal class RegisterPage
    {
        private IWebDriver driver2;
        private WebDriverWait wait;

        public RegisterPage(IWebDriver driver)
        {
            this.driver2 = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        private IWebElement GetElement(By by)
        {
            IWebElement element;
            try
            {
                element = this.driver2.FindElement(by);
            }
            catch (Exception)
            {
                element = null;
            }
            return element;
        }

        public IWebElement FirstName
        {
            get
            {
                return this.GetElement(By.Name("ime"));
            }
        }

        public IWebElement LastName
        {
            get
            {
                return this.GetElement(By.Name("prezime"));
            }
        }
        public IWebElement Email
        {
            get
            {
                return this.GetElement(By.Name("email"));
            }
        }
        public IWebElement UserName
        {
            get
            {
                return this.GetElement(By.Name("korisnicko"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.GetElement(By.Name("lozinka"));
            }
        }
        public IWebElement ConfirmPassword
        {
            get
            {
                return this.GetElement(By.Name("lozinkaOpet"));
            }
        }

        public IWebElement RegisterButton
        {
            get
            {
                return this.GetElement(By.Name("register"));
            }
        }
    }
}
