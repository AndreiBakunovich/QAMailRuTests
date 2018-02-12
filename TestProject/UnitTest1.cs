using System;
using System.Configuration;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        public string baseURL;

        private IWebElement loginField;
        private IWebElement passwordField;
        private IWebElement submitButton;

        private By signIn = By.XPath("//td[@class]//a[text()='Вход']");
        private string loginFieldPath = ("//span[@class='b-email__name']/input");
        private string passwordFieldPath = ("//form[@name='login']//*[@name='Password']");
        private By buttonRememberMeOn = By.XPath("//form[@name='login']//*[@class='js-checkbox b-checkbox b-checkbox_checked b-checkbox_' and contains(@data-bem, 'checkbox')]");
        private By buttonRememberMeOff = By.XPath("//form[@name='login']//*[@class='js-checkbox b-checkbox b-checkbox_' and contains(@data-bem, 'checkbox')]");
        private string submitButtonPath = ("//form[@name='login']//button/span[contains(text(), 'Войти')]");
        private By textErrorLogIn = By.XPath("//div[contains(text(),'Неверное имя пользователя или пароль. Проверьте правильность введенных данных.')]");
        private By loginFrame = By.CssSelector("iframe[class='ag-popup__frame__layout__iframe']");

        private string configValue = ConfigurationSettings.AppSettings["BrowserC"];


        [TestInitialize]
        public void SetupTest()
        {
            if ("FireFox".Equals(this.configValue))
            {
                var service = FirefoxDriverService.CreateDefaultService();
                this.driver = new FirefoxDriver(service);
            }
            else
            {
                if ("Chrome".Equals(this.configValue))
                {
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("disable-infobars");
                    this.driver = new ChromeDriver(option);
                }
            }

            this.baseURL = "https://mail.ru";

            this.driver.Navigate().GoToUrl(this.baseURL);
            this.driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            this.driver.FindElement(signIn).Click();
            //this.driver.SwitchTo().Frame(this.driver.FindElement(loginFrame));
            //this.driver.SwitchTo().Frame(1);

            //var frame = this.driver.SwitchTo().Frame(0);
            //this.driver.SwitchTo().Frame(1);


            IsElementVisible(By.XPath(loginFieldPath));
            loginField = driver.FindElement(By.XPath(loginFieldPath));
            passwordField = driver.FindElement(By.XPath(passwordFieldPath));
            submitButton = driver.FindElement(By.XPath(submitButtonPath));
            //JavaScriptClick(this.driver.FindElement(signIn));
            //IAlert simpleAlert = driver.SwitchTo().Alert();


            loginField.SendKeys("FakeLogin");
            passwordField.SendKeys("FakePassword");

            /*if (this.driver.FindElements(buttonRememberMeOn).Count > 0)
            {
                this.driver.FindElement(buttonRememberMeOn).Click();
            }*/

            submitButton.Click();
            //JavaScriptClick(driver.FindElement(buttonLogIn));
            Assert.IsTrue(driver.FindElements(textErrorLogIn).Count > 0);
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.driver.Close();
            this.driver.Quit();
        }

        public void IsElementVisible(By element, int timeoutSecs = 3)
        {
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeoutSecs)).Until(ExpectedConditions.ElementIsVisible(element));
        }

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

    }
}
