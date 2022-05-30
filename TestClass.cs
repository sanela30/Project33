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
using ShopOrderPage = Project33.PageObjects.OrderPage;
using ShopOrderItems = Project33.PageObjects.ListOfOrderedItems;
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
            FileManagement.WriteLine("Rows" + rows.ToString() + " Columns:" + columns.ToString());

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
                FileManagement.Write(name);

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
                        FileManagement.Write("PASS");
                        naslovna.LinkLogout();
                    }
                    else
                    {
                        TestContext.Write("FAIL");
                        FileManagement.Write("FAIL");
                        hasFailedExpected = true;
                    }
                    
                }else //Unsucceful login
                {
                    if (expected == "fail")
                    {
                        TestContext.Write("PASS");
                        FileManagement.Write("PASS");
                    }
                    else
                    {
                        TestContext.Write("FAIL");
                        FileManagement.Write("FAIL");
                        hasFailedExpected = true;
                    }
                }
                TestContext.WriteLine("({0})", description);
                FileManagement.WriteLine(" " + description);
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

        [Test]
        [Category("Order")]
        public void OrderPageTest()
        {
            QaHomePage naslovna = new QaHomePage(driver);
            naslovna.GoToPage();
            naslovna.CkickOnLoginButton();
            ShopLoginPage logIn = new ShopLoginPage(driver);
            logIn.UserName.SendKeys("MilosMiki");
            logIn.Password.SendKeys("Milos1234569");
            logIn.LogInButton.Click();
            ShopOrderPage orderMenu = new ShopOrderPage(driver);
            ShopOrderItems orderItems = new ShopOrderItems(driver);
            // System.Threading.Thread.Sleep(4000);
            
            if (logIn.WelcomeMessage != null)//Succesful login
            {
                orderMenu.Quantity.Click();
                System.Threading.Thread.Sleep(4000);
                /*orderMenu.QantitySelectValue();
                System.Threading.Thread.Sleep(4000);
                orderMenu.OrderButton.Click();*/
                
                CSVHandler CSVOrder = new CSVHandler();
                Excel.Worksheet Sheet = CSVOrder.OpenCSV(@"D:\SACUVANO\RajakKurs\32.cas\vezba32CSV\order1.csv");

                int rows = Sheet.UsedRange.Rows.Count;
                int columns = Sheet.UsedRange.Columns.Count;
                
                TestContext.WriteLine("Rows:{0},Columns:{1}", rows, columns);
                OrderFileMenagment.WriteLine("Rows" + rows.ToString() + " Columns:" + columns.ToString());
                string name;
                string value;
                string shiping;
                string expected;
                string description;
                bool hasFailedExpected1 = false;
                int pass = 0;
                int fail = 0;

                for (int i = 2; i <= rows; i++)
                {
                    name = Convert.ToString(Sheet.Cells[i, 1].Value);
                    value = Convert.ToString(Sheet.Cells[i, 2].Value);
                    shiping = Convert.ToString(Sheet.Cells[i, 3].Value);
                    expected = Convert.ToString(Sheet.Cells[i, 4].Value);
                    description = Sheet.Cells[i, 5].Value;

                    TestContext.WriteLine("Name{0} value:{1} {2} {3}", name, value, shiping, description);
                    OrderFileMenagment.Write(name);


                    if (orderMenu.Order != null)
                    {
                        orderMenu.Quantity.Click();
                        //System.Threading.Thread.Sleep(4000);

                        orderMenu.Quantity.SendKeys(value);
                        orderMenu.OrderButton.Click();
                        System.Threading.Thread.Sleep(4000);
                        
                        if (shiping != "FREE")
                          {
                             shiping = $"${shiping}";
                             
                          }
                        else
                        {
                            TestContext.Write("FAIL");
                            OrderFileMenagment.Write("FAIL");
                            hasFailedExpected1 = true;

                        }
                        TestContext.WriteLine("({0})", description);
                        OrderFileMenagment.WriteLine(" " + description);
                    }
                    if (hasFailedExpected1)
                    {
                        Assert.Fail("Some tests have unmet expected results");
                    }
                    else
                    {
                        Assert.Pass();
                    }
                    TestContext.WriteLine("Pass:{0} Fail:{1}", pass, fail);
                        CSVOrder.Close();


                }
            }
             


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
