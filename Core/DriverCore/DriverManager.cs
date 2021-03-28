using OpenQA.Selenium;
using System;
using Newtonsoft.Json;
using Core.Helper;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Core.DriverCore
{
    public class DriverManager 
    {      
        public string DataConfig = File.ReadAllText(@"..\..\..\..\Core\DataTest\Config.json");
        public IDriver ConfigDriver(string type)
        {            
            switch (type)
            {
                case "Google":
                    return new ChromeBrowser();
                case "Firefox":
                    return new FireFoxBrowser();
                default:
                    throw new Exception("Can not find browser, Check your configure file");
            }
        }
    }
}
