using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO.Compression;


namespace Core.DriverCore
{
    public class ChromeBrowser : IDriver
    {
        private IWebDriver driver;         
        public void CloseDriver()
        {           
            this.driver.Quit();          
        }

        public object DesiredCapabilities()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("start-maximized");
            options.AddArgument("--incognito");
            return options;
        }

        public IWebDriver StartDriver()
        {
            this.driver = new ChromeDriver(@"..\..\..\..\Core\DataTest\", (ChromeOptions)DesiredCapabilities());
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           
            #region type of wait

            //WebDriverWait fluentWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            //fluentWait.Timeout = TimeSpan.FromSeconds(5);
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);

            #endregion
            return this.driver;
        }
    }
}
