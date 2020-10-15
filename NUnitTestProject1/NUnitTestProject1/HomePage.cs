using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamAutomationProject
{
    public class HomePage : MainPage
    {
        string page = "https://store.steampowered.com/?l=russian";

        public void Homepage_Open()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(page);
            WaitHelper.SetExplicitWait(Driver, By.Id("language_pulldown"));
        }

        public void SelectLanguage()
        {
            IWebElement lang = Driver.FindElement(By.Id("language_pulldown"));
            lang.Click();
            IWebElement lang1 = Driver.FindElement(By.XPath("//*[contains(text(), 'английский')]"));
            lang1.Click();
            WaitHelper.SetExplicitWait(Driver, By.XPath("//div[div[text()='Browse by genre']]"));
        }

        public List<IWebElement> GetGenres()
        {
            return Driver.FindElements(By.XPath("//div[div[text()='Browse by genre']]//a")).ToList();            
        }

        public string ClickRandomGenre()
        {
            var random = new Random();
            List<IWebElement> genres = GetGenres();
            int r = random.Next(genres.Count - 1);
            var genre = genres[r].Text;
            genres[r].Click();

            return genre;
        }

        public void ClickInstallSteamButton()
        {
            IWebElement InstallSteamButton = Driver.FindElement(By.ClassName("header_installsteam_btn_content"));
            InstallSteamButton.Click();
            WaitHelper.SetExplicitWait(Driver, By.XPath("//div[a[@class = 'about_install_steam_link']]"));
        }
    }
}
