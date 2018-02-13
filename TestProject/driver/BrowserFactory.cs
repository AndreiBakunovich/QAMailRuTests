using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace TestProject.driver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver webDriver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        webDriver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                }
            }

            return webDriver;
        } 
    }
}
