using OpenQA.Selenium;
using System;
using System.Threading;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium.Support.UI;

namespace TestProject.driver
{
    public class BaseElement : IWebElement
    {
        protected string name;
        protected By locator;
        protected IWebElement element;

        public string TagName { get; }
        public string Text { get; }
        public bool Enabled { get; }
        public bool Selected { get; }
        public Point Location { get; }
        public Size Size { get; }
        public bool Displayed { get; }

        public BaseElement(By locator, string name)
        {
            this.locator = locator;
            this.name = name == "" ? this.GetText() : name;
        }

        private string GetText()
        {
            this.WaitForIsVisible();
            return this.element.Text;
        }

        public void WaitForIsVisible()
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Browser.timeoutForElement)).Until(ExpectedConditions.ElementIsVisible(this.locator));
        }

        public BaseElement(By locator)
        {
            this.locator = locator;
        }

        public IWebElement GetElement()
        {
            try
            {
                this.element = Browser.GetDriver().FindElement(this.locator);
            }
            catch (Exception)
            {
                throw;
            }
            return this.element;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            this.WaitForIsVisible();
            Browser.GetDriver().FindElement(this.locator).Click();
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void JsClick()
        {
            this.WaitForIsVisible();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", this.GetElement());
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }
    }
}
