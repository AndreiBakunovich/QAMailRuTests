using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.driver;

namespace TestProject
{
    public class Browser
    {
        private static Browser currentInstane;
        private static IWebDriver driver;
        public static BrowserFactory.BrowserType currentBrowser;
        public static int implWait;
        public static double timeoutForElement;
        private static string browser;

        private Browser()
        {
            InitParamas();
            driver = BrowserFactory.GetDriver(currentBrowser, implWait);
        }

        private static void InitParamas()
        {
            implWait = Convert.ToInt32(Configuration.ElementTimeOut);
            timeoutForElement = Convert.ToDouble(Configuration.ElementTimeOut);
            browser = Configuration.Browser;
            Enum.TryParse(browser, out currentBrowser);
        }

        public static Browser Instance => currentInstane ?? (currentInstane = new Browser());

        public static void WindowMaximise()
        {
            driver.Manage().Window.Maximize();
        }

        public static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void Quit()
        {
            driver.Quit();
            currentInstane = null;
            driver = null;
            browser = null;
        }
    }
}
