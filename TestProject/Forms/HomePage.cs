using OpenQA.Selenium;
using TestProject.driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestProject.Forms
{
    class HomePage : BaseForm
    {
        private static readonly By homeLabel = By.Id("mailbox-container");

        private readonly BaseElement signIn = new BaseElement(By.XPath("//td[@class]//a[text()='Вход']"));
        private readonly BaseElement loginFrame = new BaseElement(By.XPath("//iframe[contains(@src,'/login/?')]"));
        private readonly BaseElement loginTextField = new BaseElement(By.XPath("//span[@class='b-email__name']/input"));
        private readonly BaseElement passwordTextField = new BaseElement(By.XPath("//form[@name='login']//*[@name='Password']"));
        private readonly BaseElement submitButtonOnFrame = new BaseElement(By.XPath("//form[@name='login']//button[@data-name='submit']"));

        public HomePage() : base(homeLabel, "Home Page")
        {
        }

        public void GoToSignInPage()
        {
            signIn.WaitForIsVisible();
            signIn.GetElement().Click();
            Thread.Sleep(3000);
            Browser.GetDriver().SwitchTo().Frame(loginFrame.GetElement());
            loginTextField.WaitForIsVisible();
        }

        public void TypePassword(string password)
        {
            passwordTextField.WaitForIsVisible();
            passwordTextField.GetElement().SendKeys(password);
        }

        public void TypeLogin(string login)
        {
            loginTextField.WaitForIsVisible();
            loginTextField.GetElement().SendKeys(login);
        }

        public void ClickSubmitButtonOnFrame()
        {
            submitButtonOnFrame.WaitForIsVisible();
            submitButtonOnFrame.GetElement().Click();
            Browser.GetDriver().SwitchTo().DefaultContent();
        }

    }
}
