using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SteamAutomationProject.Services;
using System;
using System.IO;
using System.Linq;

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
            Assert.IsTrue(_homePage.IsPageOpened);

            _homePage.SelectLanguage();
            Assert.IsTrue(_homePage.IsEnglishLocalization());
        }

        [Test]
        public void SearchGamesBiggestSaleTest()
        {
            _logger.Info("Test1 started");

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
            Assert.IsTrue(games.Any(x => x.Name == name), " Games are not exists in list of gemres");
        }

        [Test]
        public void ActionsWithSteamLauncherTest()
        {
            _logger.Info("Test2 started");

            _homePage.ClickInstallSteamButton();

            var path = Directory.GetCurrentDirectory() + "SteamSetup.exe";

            var steamInstallPage = new SteamInstallPage();
            steamInstallPage.InstallSteamButtonClick();
            WaitHelper.WaitUntilFileExists(path);
            _logger.Info("clicked install button");

            var downloadanddDeleteLauncher = new LauncherService();

            Assert.IsTrue(downloadanddDeleteLauncher.DoesFileExist(path), "File not exists");
            _logger.Info("steam app installed");

            Assert.IsTrue(downloadanddDeleteLauncher.DeleteFile(path), "File is not deleted from directory");
            _logger.Info("steam app deleted from pc");
        }

        [Test]
        public void ComparisonGenreList()
        {
            _logger.Info("Test3 started");

            var path = Directory.GetCurrentDirectory() + "Gustik.txt";

            var genreElements = _homePage.GetGenres();

            var elementService = new ElementService();
            var texts = elementService.GetTextListFromElements(genreElements);

            var launcherService = new LauncherService();
            var lines = launcherService.GetRowsFromFile(path);

            var comparisonService = new ComparisonService();
            Assert.IsTrue(comparisonService.CompareLists(texts, lines), "Categories list is not correct");
            _logger.Info("comparison finished");

        }


        [TearDown]
        public void AfterTests()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot image = ((ITakesScreenshot)_driver).GetScreenshot();
                String now = DateTime.Now.ToString("MM-dd-yyy hh-mm tt ");
                string screenshotName = now + "Screenshot.png";
                image.SaveAsFile(Directory.GetCurrentDirectory()+ screenshotName, ScreenshotImageFormat.Png); //проверить работоспособность пути
                _logger.Error("Test failed"); 
            }
            DriverGenerator.Close();
        }
    }
}