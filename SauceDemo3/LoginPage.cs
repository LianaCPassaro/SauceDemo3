
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


public class LoginPage
{
    IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
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
    public bool VerifyURL()
    {
        bool main = driver.Url.Contains("https://www.saucedemo.com/inventory.html");
        return main;
    }
}
