using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SauceDemo3
{
    [TestClass]
    public class SauceLogin
    {
        [TestMethod]
        public void VerifySauceLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
            LoginPage login = new LoginPage(driver);
            login.TypeUserName();
            login.TypePassword();
            login.ClickOnLoginButton();
            driver.Quit();
        }

    }
}
