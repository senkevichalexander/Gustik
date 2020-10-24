﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SteamAutomationProject
{
    public class HomePage : MainPage
    {
        string page = "https://store.steampowered.com/";
        private const string languagePulldownCN = "language_pulldown";
        private const string languagePulldownEnglishId = "//*[@id='language_dropdown']/div/a[contains(text(), 'English')]";
        private const string languageFieldId = "//*[@id='language_dropdown']/div/a";
        private const string genresListXPath = "//div[div[text()='Browse by genre']]//a";


        public void OpenHomepage()
        {
            Driver.Navigate().GoToUrl(page);
            WaitHelper.SetExplicitWait(Driver, By.Id(languagePulldownCN));
        }

        private bool CheckEnglicshLocalization()
        {
            List<IWebElement> languages = Driver.FindElements(By.XPath(languageFieldId)).ToList();
            return languages.Any(x => x.Text.StartsWith("English"));

        }

        public void SelectLanguage()
        {
            IWebElement lang = Driver.FindElement(By.Id(languagePulldownCN));
            lang.Click();
            if (CheckEnglicshLocalization())
            {
                IWebElement lang1 = Driver.FindElement(By.XPath(languagePulldownEnglishId));
                lang1.Click();
            }
            WaitHelper.SetExplicitWait(Driver, By.XPath("//div[div[text()='Browse by genre']]"));
        }

        public List<IWebElement> GetGenres()
        {
            return Driver.FindElements(By.XPath(genresListXPath)).ToList();
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
