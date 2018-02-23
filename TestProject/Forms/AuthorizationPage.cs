using OpenQA.Selenium;
using TestProject.driver;
using System;
using OpenQA.Selenium.Support.UI;

namespace TestProject.Forms
{
    public class AuthorizationPage : BaseForm
    {
        private static readonly By homeLabel = By.XPath("//div[contains(@class, 'login_responsive') and @id='frame']");
        private static readonly By errorLogInMessageLocator = By.XPath("//div[contains(@class, 'login__errors')]");

        public AuthorizationPage() : base(homeLabel, "Authorization Page")
        {
        }

        public bool IsErrorTextPresent()
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Browser.timeoutForElement)).Until(ExpectedConditions.ElementIsVisible(errorLogInMessageLocator));
            return Browser.GetDriver().FindElements(errorLogInMessageLocator).Count > 0;
        }
    }
}
