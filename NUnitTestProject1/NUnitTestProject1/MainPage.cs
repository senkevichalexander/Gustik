using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAutomationProject
{
    public class MainPage
    {
        public IWebDriver Driver { get; } = DriverGenerator.GetInstance();
    }
}
