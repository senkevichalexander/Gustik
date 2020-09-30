using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    class SteamInstallPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public SteamInstallPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        public void InstallSteamButtonClick()
        {
            List<IWebElement> buttonClick = _driver.FindElements(By.ClassName("about_install_steam_link")).ToList();
            buttonClick[1].Click();
            Task.Delay(10000).Wait();

        }
    }
}
