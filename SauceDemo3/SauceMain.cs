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
        public void AddToCart()
        {
         mainPage = new MainPageObject(driver);
         mainPage.ClickCartButton("btn_inventory");
         Assert.AreEqual(mainPage.CountCartArticle("fa-layers-counter"), "1");
        }

    [TestCleanup]
        public void TearDown()
        {
           driver.Quit();
        }
    }
}
