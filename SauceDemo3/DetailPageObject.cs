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
    class DetailPageObject
    {
        IWebDriver driver;

        public DetailPageObject(IWebDriver driver)
        {
            this.driver = driver;

        }


    }
}
