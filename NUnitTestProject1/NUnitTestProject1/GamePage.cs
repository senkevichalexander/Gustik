using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace NUnitTestProject1
{
    class GamePage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public GamePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }
        public string GetName()
        {
            var getName = _driver.FindElement(By.ClassName("apphub_AppName")).Text;
            return getName;
        }
    }
}
