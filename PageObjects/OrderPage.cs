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
        private IWebElement GetElement(By by)
        {
            IWebElement element;
            try
            {
                element = this.driver4.FindElement(by);
            }
            catch (Exception)
            {
                element = null;
            }
            return element;
        }

        public IWebElement Order
        {
            get
            {
                return this.GetElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][4]/div[@class='col-sm-3 text-center'][3]/div[@class='panel panel-info']/div[@class='panel-body text-justify']/form/p[2]"));
            }
        }
        /* public IWebElement order = driver4.FindElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][4]/div[@class='col-sm-3 text-center'][3]/div[@class='panel panel-info']/div[@class='panel-body text-justify']/form/p[2]"));
         if (order.Displayed && order.Enabled)
         {
             System.Threading.Thread.Sleep(4000);
         }
         /*
         IWebElement quantity = driver4.FindElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][4]/div[@class='col-sm-3 text-center'][3]/div[@class='panel panel-info']/div[@class='panel-body text-justify']/form/p[@class='text-center']/select"));
         if (quantity.Displayed && quantity.Enabled)
         {
             quantity.SendKeys();
            /* SelectElement numberOfquantity = new SelectElement(quantity);
              numberOfquantity.SelectByText("4");
         }*/
        public IWebElement Quantity
        {
            get
            {
                return this.GetElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][4]/div[@class='col-sm-3 text-center'][3]/div[@class='panel panel-info']/div[@class='panel-body text-justify']/form/p[@class='text-center']/select"));
            }
        }
  
        public void QantitySelectValue()
        {
            if (this.Quantity.Displayed && this.Quantity.Enabled)
            {
                SelectElement quantity = new SelectElement(Quantity);
                quantity.SelectByText("3");
            }
        }

        public IWebElement OrderButton
        {
            get
            {
                return this.GetElement(By.XPath("/html/body/div[@class='container']/div[@class='row'][4]/div[@class='col-sm-3 text-center'][3]/div[@class='panel panel-info']/div[@class='panel-body text-justify']/form/p[@class='text-center margin-top-20']/input[@class='btn btn-primary']"));
            }
        }



        /*
            IWebElement freeShop = driver4.FindElement(By.ClassName("text-right"));
            if (freeShop.Displayed && freeShop.Enabled)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();*/
    

    }
}
