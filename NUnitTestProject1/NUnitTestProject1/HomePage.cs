using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestProject1
{
    public class Homepage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;
        
        string page = "https://store.steampowered.com/?l=russian";


        public Homepage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }
        
          public void Homepage_Open()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(page);
            _wait.Until(ExpectedConditions.ElementExists(By.Id("language_pulldown")));
        }
        public void SelectLanguage()
        {
            IWebElement lang = _driver.FindElement(By.Id("language_pulldown"));
            lang.Click();
            IWebElement lang1 = _driver.FindElement(By.XPath("//*[contains(text(), 'английский')]"));
            lang1.Click();
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[div[text()='Browse by genre']]")));
        }

        public string ClickRandomGenre()
        {
            var random = new Random();
            List<IWebElement> eles1 = _driver.FindElements(By.XPath("//div[div[text()='Browse by genre']]//a")).ToList();
            int r = random.Next(eles1.Count-1);
            var genre = eles1[r].Text;
            eles1[r].Click();

            return genre;
        }

        public void ClickInstallSteamButton()
        {
            IWebElement InstallSteamButton = _driver.FindElement(By.ClassName("header_installsteam_btn_content"));
            InstallSteamButton.Click();
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[a[@class = 'about_install_steam_link']]")));
        }
    }
}
