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
using System.Threading;

namespace SauceDemo3
{

    [TestClass]
    public class SauceMain
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
            login.SetInput("user-name", "standard_user");
            login.SetInput("password", "secret_sauce");
            login.SetButton("btn_action");
        }

        [TestMethod]
        public void ArticlePresent()
        {
            mainPage = new MainPageObject(driver);

            IWebElement articleName = mainPage.FindArticle("Sauce Labs Onesie");
            Assert.IsNotNull(articleName.Text,"The article was not been found");
        }
        [TestMethod]
        public void VerifyAccesToDetail()
        {
            mainPage = new MainPageObject(driver);
            IWebElement articleName = mainPage.FindArticle("Sauce Labs Onesie");
            if (articleName.Text != "null")
            {
                articleName.Click();
                Assert.AreEqual(login.GetURL(), "https://www.saucedemo.com/inventory-item.html?id=2");
            }
            else
            {
                throw new System.ArgumentException("Parameter cannot be null", articleName.Text);
            }
        }
        [TestMethod]
        public void AddToCartAction()
        {
         mainPage = new MainPageObject(driver);
         mainPage.ClickCartButton("btn_primary");
        Assert.AreEqual(mainPage.CountCartArticle("fa-layers-counter"), "1");
        }
        [TestMethod]
        public void RemoveToCartDisplayed()
        {
            mainPage = new MainPageObject(driver);
            mainPage.ClickCartButton("btn_primary");
            IWebElement element = mainPage.FindClassElement("btn_secondary");
            Assert.AreEqual(element.Text, "REMOVE");
        }

        [TestMethod]
        public void RemoveToCartAction()
        {
            mainPage = new MainPageObject(driver);
            mainPage.ClickCartButton("btn_secondary");
            IWebElement element = mainPage.FindClassElement("btn_primary");
            Assert.AreEqual(element.Text, "ADD TO CART");
        }

        [TestMethod]
        public void RemoveToCartActionIconCart()
        {
            mainPage = new MainPageObject(driver);
            mainPage.ClickCartButton("btn_primary");
            mainPage.ClickCartButton("btn_secondary");
            Assert.IsFalse(mainPage.FindCountCart("fa-layers-counter","0"));
            //Assert.IsTrue(mainPage.FindCountCart("fa-layers-counter","1"));
        }
        
        [TestCleanup]
        public void TearDown()
        {
           driver.Quit();
        }
    }
}
