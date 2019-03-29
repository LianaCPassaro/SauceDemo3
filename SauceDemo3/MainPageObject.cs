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
        public bool FindCountCart(string description, string count)
        {
            ReadOnlyCollection<IWebElement> anchorLists = driver.FindElements(By.ClassName(description));

            return anchorLists.Any(x => x.Text == count);
        }

        public IWebElement GetCartButton(string addToCart)
        {
            return driver.FindElement(By.ClassName(addToCart));
        }

        public void ClickCartButton(string addToCart)
        {
            GetCartButton(addToCart).Click();
        }

        public string CountCartArticle(string counter)
        {
            return driver.FindElement(By.ClassName(counter)).Text;
            // count.Click();
            //count.Text;
            //count.GetProperty("InnerText").ToString();
           //  count;

        }

        public IWebElement FindClassElement(string btn)
        {
            return driver.FindElement(By.ClassName(btn));
        }
    }
}

