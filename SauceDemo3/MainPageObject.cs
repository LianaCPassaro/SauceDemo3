using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo3
{
    class MainPageObject
    {

        IWebDriver driver;

        public MainPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string FindArticle()
        {
            string vacio = "vacio";
            ReadOnlyCollection<IWebElement> anchorLists = driver.FindElements(By.TagName("a"));
            foreach (IWebElement anchor in anchorLists)
            {
                if (anchor.Text.Contains("Sauce Labs Onesie"))
                {
                    return anchor.Text;

                }
            }
            return vacio;
        }
        public void AddToCartButton()
        {
            driver.FindElement(By.ClassName("btn_primary btn_inventory")).Click();
        }
        public void OpenArticle()
        {

            ReadOnlyCollection<IWebElement> anchorLists = driver.FindElements(By.TagName("a"));
            foreach (IWebElement anchor in anchorLists)
            {
                if (anchor.Text.Contains("Sauce Labs Onesie"))
                {
                    anchor.Click();
                    break;
                }
            }
        }
        //public int CountCartArticle()
        //{
        //    int count = driver.FindElement(By.ClassName("shopping_cart_badge")).GetAttribute(innertext);
        //    return count;
        //}
    }
}

