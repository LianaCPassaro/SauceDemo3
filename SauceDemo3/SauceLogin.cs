﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo3
{

    [TestClass]
    public class SauceLogin
    {
        IWebDriver driver;
        LoginPageObject login;
        MainPageObject mainPage;

        [TestInitialize]
        public void TestSetUp()
        {
            driver = new ChromeDriver();
            login = new LoginPageObject(driver);
            login.SetUrl("https://www.saucedemo.com/");
            login.SetCredential("user-name", "standard_user");
            login.SetCredential("password", "secret_sauce");
            login.SetButton("btn_action");
        }

        [TestMethod]
        public void VerifySuccessLogin()
        {          
            Assert.AreEqual(login.GetURL(),"https://www.saucedemo.com/inventory.html");
        }
        [TestMethod]
        public void ArticlePresent()
        {
            mainPage = new MainPageObject(driver);
            Assert.AreEqual(mainPage.FindArticle("Sauce Labs Onesie"), "Sauce Labs Onesie");
        }
        [TestMethod]
        public void VerifyAccesToDetail()
        {
            mainPage = new MainPageObject(driver);
            mainPage.FindArticle("Sauce Labs Onesie").Click();
            Assert.AreEqual(login.GetURL(),"https://www.saucedemo.com/inventory-item.html?id=2");
        }
        //public void VerifyAdd()
        //{
        //    IWebDriver driver = new ChromeDriver();
        //    LoginPageObject login = new LoginPageObject(driver);
        //    login.AccessUrl();
        //    login.TypeUserName();
        //    login.TypePassword();
        //    login.ClickOnLoginButton();

        //    MainPageObject mainPage = new MainPageObject(driver);
        //    mainPage.AddToCartButton();
        //    mainPage.CountCartArticle();
        //}
        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
