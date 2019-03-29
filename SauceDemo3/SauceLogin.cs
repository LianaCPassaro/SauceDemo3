using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo3
{

    [TestClass]
    public class SauceLogin
    {
        IWebDriver driver;
        LoginPageObject login;

        [TestInitialize]
        public void TestSetUp()
        {
            driver = new ChromeDriver();
            login = new LoginPageObject(driver);
            login.SetUrl("https://www.saucedemo.com/");
        }

        [TestMethod]
        public void VerifyMessageEmptyUserPass()
        {
            login.SetButton("btn_action");
            IWebElement error = login.FindCssElement("h3[data-test=\"error\"]");
            Assert.AreEqual(error.Text, "Epic sadface: Username is required");
        }
        [TestMethod]
        public void VerifyMessageOnlyEmptyUser()
        {
            login.SetInput("password", "secret_sauce");
            login.SetButton("btn_action");
            IWebElement error = login.FindCssElement("h3[data-test=\"error\"]");
            Assert.AreEqual(error.Text, "Epic sadface: Username is required");
        }

        [TestMethod]
        public void VerifyMessageOnlyEmptyPass()
        {
            login.SetInput("user-name", "standard_user");
            login.SetButton("btn_action");
            IWebElement error = login.FindCssElement("h3[data-test=\"error\"]");
            Assert.AreEqual(error.Text, "Epic sadface: Password is required");
        }
        [TestMethod]
        public void VerifySuccessLogin()
        {
            login.SetInput("user-name", "standard_user");
            login.SetInput("password", "secret_sauce");
            login.SetButton("btn_action");
            Assert.AreEqual(login.GetURL(), "https://www.saucedemo.com/inventory.html");
        }

        [TestCleanup]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}
