using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using QaHomePage = Project33.PageObjects.HomePage;
using QaRegisterPage=Project33.PageObjects.RegisterPage;
using ShopHomePage = Project33.PageObjects.HomePage;
using ShopLoginPage = Project33.PageObjects.LoginPage;

namespace Project33
{
    internal class TestClass
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestGoogleSearch()
        {
            QaHomePage naslovna = new QaHomePage(driver);
            naslovna.GoToPage();
           
        }
        [Test]
        [Category ("Restration")]
        public void TestRegistration()
        {
            QaRegisterPage registration = new QaRegisterPage(driver);
            QaHomePage naslovna = new QaHomePage(driver);
            naslovna.GoToPage();
            naslovna.CkickOnRegisterButton();
            registration.FirstName.SendKeys("Milos");
            registration.LastName.SendKeys("Milosevic");
            registration.Email.SendKeys("MilosMiki@huml.commm");
            registration.Password.SendKeys("Milos123456");
            registration.ConfirmPassword.SendKeys("Milos123456");
            registration.RegisterButton.Click();

        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
