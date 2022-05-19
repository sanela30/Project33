using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using NUnit.Framework;

namespace Project33.PageObjects
{
    internal class OrderPage
    {
        private IWebDriver driver4;
        private WebDriverWait wait;

        public OrderPage(IWebDriver driver)
        {
            this.driver4 = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void OrderMenu()
        {
            IWebElement order = driver4.FindElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][4]/div[@class='col-sm-3 text-center'][3]/div[@class='panel panel-info']/div[@class='panel-body text-justify']/form/p[2]"));
            if (order.Displayed && order.Enabled)
            {
                System.Threading.Thread.Sleep(4000);
            }

            IWebElement quantity = driver4.FindElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][4]/div[@class='col-sm-3 text-center'][3]/div[@class='panel panel-info']/div[@class='panel-body text-justify']/form/p[@class='text-center']/select"));
            if (quantity.Displayed && quantity.Enabled)
            { 
                SelectElement numberOfquantity = new SelectElement(quantity);
                 numberOfquantity.SelectByText("4");
            }

            IWebElement orderButton = driver4.FindElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][4]/div[@class='col-sm-3 text-center'][3]/div[@class='panel panel-info']/div[@class='panel-body text-justify']/form/p[@class='text-center margin-top-20']/input[@class='btn btn-primary']"));
            if (orderButton.Displayed && orderButton.Enabled)
            {
                orderButton.Click();
                System.Threading.Thread.Sleep(4000);
            }

            IWebElement freeShop = driver4.FindElement(By.ClassName("text-right"));
            if (freeShop.Displayed && freeShop.Enabled)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
         }
    }
}
