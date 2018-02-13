using System;
using System.Configuration;
//using System.Drawing;
//using System.Runtime.Remoting.Channels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Chrome;
//using System.Collections.Generic;

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
        private By loginFrameLocator = By.XPath("//iframe[@class='ag-popup__frame__layout__iframe']");
        private string loginFieldPath = ("//span[@class='b-email__name']/input");
        private string passwordFieldPath = ("//form[@name='login']//*[@name='Password']");
        private By buttonRememberMeOn = By.XPath("//form[@name='login']//input[@name='saveauth' and @value='1']");
        private By buttonRememberMe = By.XPath("//form[@name='login']//*[contains(@class, 'js-checkbox b-checkbox b-checkbox_') and contains(@data-bem, 'checkbox')]");////div[@class='b-checkbox__box']
        private string submitButtonPath = ("//form[@name='login']//button/span[contains(text(), 'Войти')]");
        private By textErrorLogIn = By.XPath("//div[contains(text(),'Неверное имя пользователя или пароль. Проверьте правильность введенных данных.')]");
        private By loginFrame = By.XPath("");

        private string configValue = ConfigurationSettings.AppSettings["Browser"];


        [TestInitialize]
        public void SetupTest()
        {
            if ("FF".Equals(this.configValue))
            {
                var service = FirefoxDriverService.CreateDefaultService();
                this.driver = new FirefoxDriver(service);
            }
            else
            {
                if ("C".Equals(this.configValue))
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            this.driver.FindElement(signIn).Click();
            //this.driver.SwitchTo().Frame(this.driver.FindElement(loginFrame));

            driver.SwitchTo().Frame(driver.FindElement(loginFrameLocator));
            IsElementVisible(By.XPath(loginFieldPath));
            loginField = driver.FindElement(By.XPath(loginFieldPath));
            passwordField = driver.FindElement(By.XPath(passwordFieldPath));
            submitButton = driver.FindElement(By.XPath(submitButtonPath));


            loginField.SendKeys("FakeLogin");
            passwordField.SendKeys("FakePassword");

            if (this.driver.FindElements(buttonRememberMeOn).Count > 0)
            {
                this.driver.FindElement(buttonRememberMe).Click();
            }

            submitButton.Click();
            Assert.IsTrue(driver.FindElements(textErrorLogIn).Count > 0);
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.driver.Close();
            this.driver.Quit();
        }

        public void IsElementVisible(By element, int timeoutSecs = 10)
        {
            //var frameDriver = driver.SwitchTo().Frame(driver.FindElement(loginFrameLocator));
            //frameDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //Thread.Sleep(3000);
            //var webElement = frameDriver.FindElements(element);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSecs));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(element));
        }

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

    }
}
