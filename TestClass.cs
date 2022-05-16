using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using QaHomePage = Project33.PageObjects.HomePage;
using QaRegisterPage=Project33.PageObjects.RegisterPage;
using ShopLoginPage = Project33.PageObjects.LoginPage;
using Excel = Microsoft.Office.Interop.Excel;
using Project33.libraries;

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
            registration.FirstName.SendKeys("Milosh");
            registration.LastName.SendKeys("Milosevich");
            registration.Email.SendKeys("MilosMikic@huml.commm");
            registration.UserName.SendKeys("MilosMiki");
            registration.Password.SendKeys("Milos1234569");
            registration.ConfirmPassword.SendKeys("Milos1234569");
            registration.RegisterButton.Click();

        }
        [Test]
        [Category("LogIn")]
        public void TestLogin()
        {
            CSVHandlers CSV = new CSVHandlers();
            Excel.Worksheet Sheet = CSV.OpetCSV(@"D:\SACUVANO\RajakKurs\32.cas\vezba32CSV");

            ShopLoginPage logIn = new ShopLoginPage(driver);
            QaHomePage naslovna = new QaHomePage(driver);
            naslovna.GoToPage();
            naslovna.CkickOnLoginButton();
            logIn.UserName.SendKeys("MilosMiki");
            logIn.Password.SendKeys("Milos1234569");
            logIn.LogInButton.Click();
            if(logIn.WelcomeMessage != null)
            {
                Assert.Pass("Login is successful");
            }
            else
            {
                Assert.Fail();
            }


        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
