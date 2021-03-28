using System;
using Core.DriverCore;
using OpenQA.Selenium;
using Core.Helper;
using System.Threading;

namespace FinalASM_TanNV23.Test
{
    public class BaseTest : IDisposable
    {
        public IWebDriver Driver;
        protected DriverManager drivermanager = new DriverManager();
        //protected string browser = "Google";
        private string environmet => JsonTool.GetPropertyValue(drivermanager.DataConfig, "Environment[0].WEB");

        public BaseTest()
        {         
        }

        // written new line abc 
        // fetch check

        public void GetBrowser(string browser)
        {           
            this.Driver = drivermanager.ConfigDriver(browser).StartDriver();
            this.Driver.Navigate().GoToUrl(this.environmet);
        }

        public void Dispose()
        {
            Thread.Sleep(300);
            this.Driver.Quit();
        }
    }
}
