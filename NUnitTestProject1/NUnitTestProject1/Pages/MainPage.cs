using OpenQA.Selenium;

namespace SteamAutomationProject
{
    public class MainPage
    {
        public IWebDriver Driver { get; } = DriverGenerator.GetInstance();
    }
}
