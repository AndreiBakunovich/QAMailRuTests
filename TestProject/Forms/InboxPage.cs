using OpenQA.Selenium;
using TestProject.driver;

namespace TestProject.Forms
{
    public class InboxPage : BaseForm
    {
        private static readonly By homeLabel = By.XPath("//div[contains(@class,'letters_from')]");

        private readonly By sentMailsLocator = By.XPath("//*[contains(@href,'sent')]");
        private readonly By drafMailstsLocator = By.XPath("//*[contains(@href,'drafts')]");
        private readonly By spamMailsLocator = By.XPath("//*[contains(@href,'spam')]");
        private readonly By trashMailsLocator = By.XPath("//*[contains(@href,'trash')]");

        protected InboxPage() : base(homeLabel, "Inbox")
        {
        }

        public void ClickSentMailButton()
        {
            this.
        }
    }
}
