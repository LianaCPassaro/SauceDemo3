﻿using System;
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

        public IWebElement FindArticle(string description)
        {
            ReadOnlyCollection<IWebElement> anchorLists = driver.FindElements(By.TagName("a"));

            return anchorLists.FirstOrDefault(x => x.Text == description);
        }

        public void AddToCartButton()
        {
            driver.FindElement(By.ClassName("btn_primary btn_inventory")).Click();
        }
        
        //public int CountCartArticle()
        //{
        //    int count = driver.FindElement(By.ClassName("shopping_cart_badge")).GetAttribute(innertext);
        //    return count;
        //}
    }
}

