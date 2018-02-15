using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.driver;
using TestProject.Forms;

namespace TestProject
{
    [TestFixture]
    public class UnitTests : BaseTest
    {
        private IWebDriver driver;

        [Test]
        public void IsIncorrectAuthorizationIsFailedTest()
        {
            driver = Browser.GetDriver();
            HomePage homePage = new HomePage();

            homePage.GoToSignInPage();
            homePage.TypeLogin("FakeLogin");
            homePage.TypePassword("FakePassword");
            homePage.ClickSubmitButtonOnFrame();

            AuthorizationPage authorizationPage = new AuthorizationPage();
            Assert.IsTrue(authorizationPage.IsErrorTextPresent());
        }

        [Test]
        public void LoginTest()
        {
            driver = Browser.GetDriver();
            HomePage homePage = new HomePage();

            homePage.GoToSignInPage();
            homePage.TypeLogin(Configuration.Login);
            homePage.TypePassword(Configuration.Password);
            homePage.ClickSubmitButtonOnFrame();
            
            //driver.FindElement(By.XPath("//div[contains(@class, 'b-datalist__body')]//div")).Click();

            Assert.IsTrue(driver.FindElements(By.XPath("//div[contains(@class, 'b-datalist__body')]//div")).Count > 0);
        }
    }
}
