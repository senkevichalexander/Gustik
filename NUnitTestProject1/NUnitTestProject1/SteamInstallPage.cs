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

namespace SteamAutomationProject
{
    class SteamInstallPage : MainPage
    {
        public void InstallSteamButtonClick()
        {
            List<IWebElement> buttonClick = Driver.FindElements(By.ClassName("about_install_steam_link")).ToList();
            buttonClick[1].Click();
            Task.Delay(10000).Wait();
        }
    }
}
