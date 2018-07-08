using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebArrdessbookTests
{
    public class HelperBase
    {
        public IWebDriver driver;

        public HelperBase (IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
