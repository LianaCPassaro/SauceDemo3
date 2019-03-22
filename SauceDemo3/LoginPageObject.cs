
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
    public void SetInput(string attrib, string value)
    {
        GetInput(attrib).SendKeys(value);
    }

    public IWebElement GetInput(string attrib)
    {
        return driver.FindElement(By.Id(attrib));
    }
    
    //public IWebElement GetElement(Type //id, name, css, string selector)
    //{
        
    //    return driver.FindElement(By.type(selector));
    //}


    public IWebElement GetButton(string btnLogin)
    {
        return driver.FindElement(By.ClassName(btnLogin));
    }
    public void SetButton(string btnLogin)
    {
        GetButton(btnLogin).Click();
    }


}
