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
            CSVHandler CSV = new CSVHandler();
            Excel.Worksheet Sheet = CSV.OpenCSV(@"D:\SACUVANO\RajakKurs\32.cas\vezba32CSV\new1.csv");

            int rows = Sheet.UsedRange.Rows.Count;
            int columns=Sheet.UsedRange.Columns.Count;

            TestContext.WriteLine("Rows:{0},Columns:{1}",rows,columns);

            string username;
            string password;
            string description;

            int pass = 0;
            int fail = 0;

            for (int i=2; i<=rows; i++)
            {
                username = Sheet.Cells[i, 1].Value;
                password= Sheet.Cells[i, 2].Value;
                description= Sheet.Cells[i, 3].Value;
                TestContext.WriteLine("Username: {0} Password: {1} Description: {2}", username, password,description);
                if (driver == null)
                {
                    SetUp();
                }

                ShopLoginPage logIn = new ShopLoginPage(driver);
                QaHomePage naslovna = new QaHomePage(driver);
                naslovna.GoToPage();
                naslovna.CkickOnLoginButton();
                logIn.UserName.SendKeys(username);
                logIn.Password.SendKeys(password);
                logIn.LogInButton.Click();
                System.Threading.Thread.Sleep(4000);
                if (logIn.WelcomeMessage != null)
                {
                    pass++;
                    naslovna.LinkLogout();
                }
                else
                {
                    fail++;
                }

                
                
            }

            TestContext.WriteLine("Pass:{0} Fail:{1}", pass, fail);
            CSV.Close();


        }


        [TearDown]
        public void TearDown()
        {
            if(driver != null)
            {
                driver.Close();
            }
            
        }
    }
}
