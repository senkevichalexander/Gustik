using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using SteamAutomationProject.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
            _homePage.OpenHomepage();
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

                var path = Directory.GetCurrentDirectory() + "SteamSetup.exe";

                var steamInstallPage = new SteamInstallPage();
                steamInstallPage.InstallSteamButtonClick();
                WaitHelper.WaitUntilFileExists(path);
                _logger.Info("clicked install button");

                var downloadanddDeleteLauncher = new LauncherService();

                Assert.IsTrue(downloadanddDeleteLauncher.CheckFileExists(path));
                _logger.Info("steam app installed");

                Assert.IsTrue(downloadanddDeleteLauncher.DeleteFile(path));
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
                var path = Directory.GetCurrentDirectory() + "Gustik.txt"; 
                
                var genreElements = _homePage.GetGenres();

                var elementService = new ElementService();
                var texts = elementService.GetTextListFromElements(genreElements);

                var launcherService = new LauncherService();
                var lines = launcherService.GetRowsFromFile(path);

                var comparisonService = new ComparisonService();
                Assert.IsTrue(comparisonService.CompareLists(texts, lines));
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