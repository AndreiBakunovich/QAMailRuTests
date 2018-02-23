using OpenQA.Selenium;
using TestProject.driver;

namespace TestProject.Forms
{
    public class Inbox : BaseForm
    {
        private static readonly By homeLabel = By.XPath("//div[contains(@class,'letters_from')]");

        private readonly By sentButtonLocator = By.XPath("//*[contains(@href,'sent')]");
        private readonly By drafButtontsLocator = By.XPath("//*[contains(@href,'drafts')]");
        private readonly By spamButtonLocator = By.XPath("//*[contains(@href,'spam')]");
        private readonly By trashButtonLocator = By.XPath("//*[contains(@href,'trash')]");

        protected Inbox() : base(homeLabel, "Inbox")
        {
        }
    }
}
