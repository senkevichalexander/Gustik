using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAutomationProject
{
    public static class WaitHelper
    {
        public static void SetExplicitWait(IWebDriver driver, By by, int timeout = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementExists(by));
            //IWebElement element = wait.Until<IWebElement>((d) =>
            //{
            //    return d.FindElement(by);
            //});
        }
    }
}
