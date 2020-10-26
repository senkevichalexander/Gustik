using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SteamAutomationProject
{
    class SteamInstallPage : MainPage
    {
        private const string installButtonCN = "about_install_steam_link"; 
        public void InstallSteamButtonClick()
        {
            List<IWebElement> buttonClick = Driver.FindElements(By.ClassName(installButtonCN)).ToList();
            buttonClick[1].Click();
        }
    }
}
