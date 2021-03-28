using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;


namespace Core.DriverCore
{
    public class FireFoxBrowser : IDriver
    {
        private static IWebDriver driver;
        public void CloseDriver()
        {
            driver.Quit();
        }

        public object DesiredCapabilities()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument(@"--start-maximized");
            options.AddArgument(@"--incognito");
            return options;
        }

        public IWebDriver StartDriver()
        {
            System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"..\..\..\..\");            
            driver = new FirefoxDriver(@"..\..\..\..\Core\DataTest\",(FirefoxOptions)DesiredCapabilities());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
