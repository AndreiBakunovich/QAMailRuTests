using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.driver
{
    class BaseTest
    {
        protected static Browser Browser = Browser.Instance;

        [TestInitialize]
        public virtual void InitTest()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximise();
            Browser.NavigateTo(Configuration.StartURL);
        }

        [TestCleanup]
        public virtual void CleanTest()
        {
            Browser.Quit();
        }
    }
}
