using System;
using OpenQA.Selenium;
using Core.Handle;


namespace FinalASM_TanNV23.Page
{
    public class BasePage
    {
        public IWebDriver driver;

        protected Elements findElements;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            findElements = new Elements(driver);
        }
    }
}


