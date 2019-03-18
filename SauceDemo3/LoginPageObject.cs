
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


public class LoginPageObject
{
    IWebDriver driver;


    public LoginPageObject(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void AccessUrl()
    {
       // driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        driver.Manage().Window.Maximize();
    }

    public void TypeUserName()
    {
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
    }
    public void TypePassword()
    {
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
    }
    public void ClickOnLoginButton()
    {
        driver.FindElement(By.ClassName("btn_action")).Click();
    }
    public bool VerifyURL(string url)
    {
        bool main = driver.Url.Contains(url);
        return main;
    }
}
