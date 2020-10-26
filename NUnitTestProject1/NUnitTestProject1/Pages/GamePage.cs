using OpenQA.Selenium;

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
