using OpenQA.Selenium;
using System;
using TestProject.driver;

namespace TestProject.Forms
{
    public class Inbox : BaseForm
    {
        private static readonly By homeLabel = By.Id("mailbox-container");

        protected Inbox() : base(homeLabel, "Inbox")
        {
        }
    }
}
