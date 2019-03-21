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

        public IWebElement FindArticle(string description)
        {
            ReadOnlyCollection<IWebElement> anchorLists = driver.FindElements(By.TagName("a"));

            return anchorLists.FirstOrDefault(x => x.Text == description);
        }
        public IWebElement GetCartButton(string addToCart)
        {
            return driver.FindElement(By.ClassName(addToCart));
        }

        public void SetCartButton(string addToCart)
        {
            GetCartButton(addToCart).Click();
        }

        public IWebElement CountCartArticle(string counter)
        {
            IWebElement count = driver.FindElement(By.ClassName("fa-layers-counter"));
           // count.Click();
            count.GetProperty("InnerText").ToString();
            return count;

        }
    }
}

