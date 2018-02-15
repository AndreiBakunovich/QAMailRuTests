using NUnit.Framework;

namespace TestProject.driver
{
    public class BaseTest
    {
        protected static Browser Browser = Browser.Instance;

        [SetUp]
        public virtual void InitTest()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximise();
            Browser.NavigateTo(Configuration.StartURL);
        }

        [TearDown]
        public virtual void CleanTest()
        {
            Browser.Quit();
        }
    }
}
