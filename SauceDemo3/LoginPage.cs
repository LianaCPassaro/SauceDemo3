using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class LoginPage
{
    IWebDriver driver;
    By UserName = By.Id("user-name");  
    By Password = By.Id("password");
    By loginButton = By.ClassName("btn_action");

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        
    }
    public void TypeUserName()
    {
        driver.FindElement(UserName).SendKeys("standard_user");
    }
    public void TypePassword()
    {
        driver.FindElement(Password).SendKeys("secret_sauce");
    }
    public void ClickOnLoginButton()
    {
        driver.FindElement(loginButton).Click();
    }
}
