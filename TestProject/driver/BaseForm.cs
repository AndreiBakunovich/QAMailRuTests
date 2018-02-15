using OpenQA.Selenium;

namespace TestProject.driver
{
    public class BaseForm
    {
        protected By titleLocator;
        protected string title;
        public static string titleForm;

        protected BaseForm(By titleLocator, string title)
        {
            this.titleLocator = titleLocator;
            this.title = title;
            AssertIsOpen();
        }

        private void AssertIsOpen()
        {
            var label = new BaseElement(this.titleLocator, this.title);
            label.WaitForIsVisible();
        }
    }
}
