using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo3
{
    [TestClass]
    public class SauceLogin
    {
        [TestMethod]
        public void VerifySauceLogin()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPageObject login = new LoginPageObject(driver);
            login.AccessUrl();
            login.TypeUserName();
            login.TypePassword();
            login.ClickOnLoginButton();
            Assert.AreEqual(login.GetURL(),"https://www.saucedemo.com/inventory.html");
            driver.Quit();
        }
        [TestMethod]
        public void VerifyMainPage()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPageObject login = new LoginPageObject(driver);
            login.AccessUrl();
            login.TypeUserName();
            login.TypePassword();
            login.ClickOnLoginButton();

            MainPageObject mainPage = new MainPageObject(driver);
            string article = mainPage.FindArticle();
            Assert.AreEqual(article, "Sauce Labs Onesie");
            driver.Quit();
        }
        [TestMethod]
        public void VerifyAccesToDetail()
        {
            IWebDriver driver = new ChromeDriver();
            LoginPageObject login = new LoginPageObject(driver);
            login.AccessUrl();
            login.TypeUserName();
            login.TypePassword();
            login.ClickOnLoginButton();

            MainPageObject mainPage = new MainPageObject(driver);
            mainPage.OpenArticle();
            Assert.IsTrue(login.VerifyURL("https://www.saucedemo.com/inventory-item.html?id=2"));
            driver.Quit();
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
    }
}
