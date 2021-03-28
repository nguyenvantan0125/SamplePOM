using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Core.Handle
{
    public class Elements
    {
        private readonly IWebDriver _driver;
        public Elements(IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebElement CssElement(string content)
        {            
            return this._driver.FindElement(By.CssSelector(content));
        }

        public IWebElement XpathElement(string content)
        {
            return this._driver.FindElement(By.XPath(content));
        }
    }
}
