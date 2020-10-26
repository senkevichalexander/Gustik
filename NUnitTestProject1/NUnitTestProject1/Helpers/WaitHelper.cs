using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Threading;

namespace SteamAutomationProject
{
    public static class WaitHelper
    {
        public static void SetExplicitWait(IWebDriver driver, By by, int timeout = 40)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementExists(by));
            //IWebElement element = wait.Until<IWebElement>((d) =>
            //{
            //    return d.FindElement(by);
            //});
        }

        public static void WaitUntilFileExists(string path)
        {
            for (var i = 0; i < 30; i++)
            {
                if (File.Exists(path)) { break; }
                Thread.Sleep(1000);
            }

        }
    }
}
