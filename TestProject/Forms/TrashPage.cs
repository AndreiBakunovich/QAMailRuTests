using TestProject.driver;
using OpenQA.Selenium;

namespace TestProject.Forms
{
    class TrashPage : BaseForm
    {
        private static readonly By trashLabel = By.XPath("");

        protected TrashPage() : base(homeLabel, "Inbox")
        {
        }
    }
}
