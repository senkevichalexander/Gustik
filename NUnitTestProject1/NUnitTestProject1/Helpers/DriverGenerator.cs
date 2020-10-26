using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace SteamAutomationProject
{
    public  class DriverGenerator
    {
        private static IWebDriver driver;
        private static bool isOpen;
        public static IWebDriver GetInstance()
        {
            if (driver == null || !isOpen)
            {
                var options = new ChromeOptions();

                options.AddUserProfilePreference("download.prompt_for_download", false);
                options.AddUserProfilePreference("download.directory_upgrade", true);
                options.AddUserProfilePreference("safebrowsing.enabled", true);
                options.AddUserProfilePreference("download.default_directory", Directory.GetCurrentDirectory());
                driver = new ChromeDriver(options);
                driver.Manage().Window.Maximize();// open
                isOpen = true;
            }

            return driver;
        }

        public static void Close()
        {
            driver.Close();
            isOpen = false;
        }
    }
}
