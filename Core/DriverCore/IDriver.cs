using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DriverCore
{
    public interface IDriver
    {
        IWebDriver StartDriver();
        object DesiredCapabilities();
        void CloseDriver();
    }
}
