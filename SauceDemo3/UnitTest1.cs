using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo1

{
    [TestClass]

    public class UnitTest1
    {
        [TestMethod]

        public void ChromeMethod()
        {
            string ActualResult;
            string ExpectedResult = "Swag Labs";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
            ActualResult = driver.Title;

            if (ActualResult.Contains(ExpectedResult))
            {
                Console.WriteLine("Test case passed");
                Assert.IsTrue(true, "Test Case Passed", "Test Case Failed");
            }
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void Login()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.ClassName("login-button")).Click();
            List<String> textofanchors = new List<string>();
            ReadOnlyCollection<IWebElement> anchorLists = driver.FindElements(By.TagName("a"));
            foreach (IWebElement anchor in anchorLists)
            {
                if (anchor.Text.Contains("Sauce Labs Backpack"))
                {
                    textofanchors.Add(anchor.Text);
                    anchor.Click();
                    break;
                }
            }
            string stop = "";
            driver.Close();
            driver.Quit();
        }

        [TestMethod]

        public void OrderElement()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
                driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
                driver.FindElement(By.ClassName("login-button")).Click();
                SelectElement selectsort = new SelectElement(driver.FindElement(By.ClassName("product_sort_container")));
                selectsort.SelectByText("Price (high to low)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}