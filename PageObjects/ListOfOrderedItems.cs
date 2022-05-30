using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using NUnit.Framework;


namespace Project33.PageObjects
{
    internal class ListOfOrderedItems
    {
        private IWebDriver driver5;
        private WebDriverWait wait;

        public ListOfOrderedItems(IWebDriver driver)
        {
            this.driver5 = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        private IWebElement GetElement(By by)
        {
            IWebElement element;
            try
            {
                element = this.driver5.FindElement(by);
            }
            catch (Exception)
            {
                element = null;
            }
            return element;
        }

        public IWebElement Shiping
        {
            get
            {
                return this.GetElement(By.XPath("//td[contains(text(), 'FREE')]"));
            }
        }

        public IWebElement ContinueShoping
        {
            get
            {
                return this.GetElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][3]/div[@class='col-sm-12 text-right margin-top-20']/form/a[@class='btn btn-default']"));

            }   
        }
    }
}
