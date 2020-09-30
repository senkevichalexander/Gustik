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

namespace NUnitTestProject1
{
    public class Tests
    {
        private IWebDriver _driver;
        private Homepage _homePage;
        private Logger _logger;


        [SetUp]
        public void Setup()
        {
            _logger = LogManager.GetCurrentClassLogger();
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);

            _driver = new ChromeDriver(options);
            _homePage = new Homepage(_driver);
            _homePage.Homepage_Open();
            _homePage.SelectLanguage();
        }

        [Test]
        public void Test1()
        {
            _logger.Info("Test1 started");

            try
            {
                var genre = _homePage.ClickRandomGenre();
                _logger.Info("Genre is getted");
                GenrePage genrePage = new GenrePage(_driver);
                var games = genrePage.GetGames();
                _logger.Info("Game list is parsed");
                genrePage.ClickGameWithTheBiggestSale();
                _logger.Info("Gettng game with biggest sale");
                GamePage gamePage = new GamePage(_driver);
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
        public void Test2()
        {
            _logger.Info("Test2 started");

            try
            {
                _homePage.ClickInstallSteamButton();
                SteamInstallPage steamInstallPage = new SteamInstallPage(_driver);
                steamInstallPage.InstallSteamButtonClick();
                _logger.Info("clicked install button");
                LauncherService downloadanddDeleteLauncher = new LauncherService(_driver);
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

        public void Test3()
        {
            _logger.Info("Test3 started");

            try
            {

                TagComparison tagComparison = new TagComparison(_driver);
                Assert.IsTrue(tagComparison.CompareLists());
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
            _driver.Close();
        }
    }
}