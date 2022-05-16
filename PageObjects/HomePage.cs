using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Project33.PageObjects
{
    internal class HomePage
    {
        private IWebDriver driver1;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver1 = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void GoToPage()
        {
            driver1.Navigate().GoToUrl("http://shop.qa.rs//");
            wait.Until(EC.ElementIsVisible(By.XPath("/html/body/div[@class='container']/div[@class='row'][3]/div[@class='col-sm-6 text-center'][2]/a")));

            System.Threading.Thread.Sleep(4000);
        }

        public void CkickOnRegisterButton()
        {
            IWebElement register = driver1.FindElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][3]/div[@class='col-sm-6 text-center'][2]/a"));
            if (register.Displayed && register.Enabled)
            {
                register.Click();
            }
        }

        public void CkickOnLoginButton()
        {
            IWebElement logIn = driver1.FindElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][3]/div[@class='col-sm-6 text-center'][1]/a"));
            if (logIn.Displayed && logIn.Enabled)
            {
                logIn.Click();

            }
        }


    }
}
