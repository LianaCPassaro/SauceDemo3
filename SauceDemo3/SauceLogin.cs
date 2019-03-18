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
            Assert.IsTrue(login.VerifyURL());
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
        }
        //[TestCleanup]
        //public void Close(IWebDriver driver)
        //{
        //    driver.Quit();
        //}

    }
}
