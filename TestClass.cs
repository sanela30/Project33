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

            string name;
            string username;
            string password;
            string description;
            string expected;

            int pass = 0;
            int fail = 0;
            bool hasFailedExpected = false;

            for (int i=2; i<=rows; i++)
            {
                name =Sheet.Cells[i, 1].Value;
                username = Sheet.Cells[i, 2].Value;
                password= Sheet.Cells[i, 3].Value;
                expected = Sheet.Cells[i, 4].Value;
                description = Sheet.Cells[i, 5].Value;
                
                TestContext.WriteLine("{0}",name);

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
                if (logIn.WelcomeMessage != null)//Succesful login
                {
                    if (expected == "pass")
                    {
                        TestContext.Write("PASS");
                        naslovna.LinkLogout();
                    }
                    else
                    {
                        TestContext.Write("FAIL");
                        hasFailedExpected = true;
                    }
                    
                }else //Unsucceful login
                {
                    if (expected == "fail")
                    {
                        TestContext.Write("PASS");
                    }
                    else
                    {
                        TestContext.Write("FAIL");
                        hasFailedExpected = true;
                    }
                }
                TestContext.WriteLine("({0})", description);
            }
            if (hasFailedExpected)
            {
                Assert.Fail("Some tests have unmet expected results");
            }else
            {
                Assert.Pass();
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
