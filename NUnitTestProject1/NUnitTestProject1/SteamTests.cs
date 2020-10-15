using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace SteamAutomationProject
{
    public class SteamTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private Logger _logger;


        [SetUp]
        public void Setup()
        {
            _driver = DriverGenerator.GetInstance();
            _logger = LogManager.GetCurrentClassLogger();
            _homePage = new HomePage();
            _homePage.Homepage_Open();
            _homePage.SelectLanguage();
        }

        [Test]
        public void SearchGamesBiggestSaleTest()
        {
            _logger.Info("Test1 started");

            try
            {
                var genre = _homePage.ClickRandomGenre();
                _logger.Info("Genre is getted");
                GenrePage genrePage = new GenrePage();
                var games = genrePage.GetGames();
                _logger.Info("Game list is parsed");
                genrePage.ClickGameWithTheBiggestSale();
                _logger.Info("Gettng game with biggest sale");
                GamePage gamePage = new GamePage();
                var name = gamePage.GetName();
                _logger.Info("Checked game in list of genres");
                Assert.IsTrue(games.Any(x => x.Name == name));
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                Screenshot image = ((ITakesScreenshot)_driver).GetScreenshot();
                image.SaveAsFile("C:/Users/Alexandra/Downloads/screen.png", ScreenshotImageFormat.Png);
            }
        }

        [Test]
        public void ActionsWithSteamLauncherTest()
        {
            _logger.Info("Test2 started");

            try
            {
                _homePage.ClickInstallSteamButton();
                SteamInstallPage steamInstallPage = new SteamInstallPage();
                steamInstallPage.InstallSteamButtonClick();
                _logger.Info("clicked install button");
                LauncherService downloadanddDeleteLauncher = new LauncherService();
                downloadanddDeleteLauncher.DownloadFile();
                _logger.Info("steam app installed");
                downloadanddDeleteLauncher.DeleteFile();
                _logger.Info("steam app deleted from pc");
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                Screenshot image = ((ITakesScreenshot)_driver).GetScreenshot();
                image.SaveAsFile("C:/Users/Alexandra/Downloads/screen.png", ScreenshotImageFormat.Png);
            }
        }

        [Test]
        public void ComparisonGenreList()
        {
            _logger.Info("Test3 started");

            try
            {
                List<IWebElement> genreElements = _homePage.GetGenres();
                List<string> texts = genreElements.Select(x => x.Text).ToList();

                TagComparison tagComparison = new TagComparison();
                Assert.IsTrue(tagComparison.CompareLists(texts));
                _logger.Info("comparison finished");
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                Screenshot image = ((ITakesScreenshot)_driver).GetScreenshot();
                image.SaveAsFile("C:/Users/Alexandra/Downloads/screen.png", ScreenshotImageFormat.Png);
            }

        }


        [TearDown]
        public void AfterTests()
        {
            DriverGenerator.Close();
        }
    }
}