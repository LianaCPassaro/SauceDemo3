
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

    public void SetUrl(string url)
    {
        driver.Navigate().GoToUrl(url);
        driver.Manage().Window.Maximize();
    }
    public string GetURL()
    {
        return driver.Url;
    }
    public void SetCredential(string attrib, string value)
    {
        GetCredential(attrib).SendKeys(value);
    }

    public IWebElement GetCredential(string attrib)
    {
        return driver.FindElement(By.Id(attrib));
    }

    public IWebElement GetButton(string btnLogin)
    {
        return driver.FindElement(By.ClassName(btnLogin));
    }
    public void SetButton(string btnLogin)
    {
        GetButton(btnLogin).Click();
    }


}
