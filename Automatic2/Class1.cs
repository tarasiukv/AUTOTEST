using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Automatic2
{
    [TestFixture]
    public class Class1
    {
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArguments
                (
                    "--start-maximized",
                    "--disable-extensions",
                    "--disable-notifications",
                    "--disable-application-cache"
                );

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://automationpractice.com");

            IWebElement LoginButtom = driver.FindElement(By.LinkText("Sign in"));
            LoginButtom.Click();

            IWebElement login = driver.FindElement(By.Name("email"));
            login.SendKeys("testtestuser@gmail.com");

            IWebElement password = driver.FindElement(By.Name("passwd"));
            password.SendKeys("0678732728viktor");

            IWebElement auth = driver.FindElement(By.Name("SubmitLogin"));
            auth.Click();

        }

        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }

        [Test]
        public void CheckAccount()
        {

            var Account= driver.FindElement(By.ClassName("account"));
            Account.Click();

            Assert.AreEqual("My account - My Store", driver.Title);

        }

        [Test]
        public void ChekPersonalPage()
        {

            var Account = driver.FindElement(By.ClassName("account"));
            Account.Click();

            var PerInf  = driver.FindElement(By.ClassName("icon-user"));
            PerInf.Click();

            IWebElement firstname = driver.FindElement(By.Name("firstname"));
            firstname.Clear();
            firstname.SendKeys("Viktor");

            IWebElement lastname = driver.FindElement(By.Name("lastname"));
            lastname.Clear();
            lastname.SendKeys("Tarasiuk");

            IWebElement password = driver.FindElement(By.Name("old_passwd"));
            password.SendKeys("0678732728viktor");


            var SaveButtom = driver.FindElement(By.Name("submitIdentity"));
            SaveButtom.Click();


            var User = driver.FindElement(By.ClassName("account"));
            Assert.AreEqual("Viktor Tarasiuk", User.Text);

            driver.Quit();

        }
    }
}