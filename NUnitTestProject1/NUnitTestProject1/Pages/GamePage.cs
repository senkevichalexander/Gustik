using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SteamAutomationProject
{
    class GamePage : MainPage
    {
        private const string gameName = "apphub_AppName";
        public string GetName()
        {
            var getName = Driver.FindElement(By.ClassName(gameName)).Text;
            return getName;
        }
    }
}
