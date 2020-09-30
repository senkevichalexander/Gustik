using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace NUnitTestProject1
{
    class GenrePage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public GenrePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        public List<Game> GetGames()
        {
            List<IWebElement> gamesElements = _driver.FindElements(By.XPath("//div[@id='NewReleasesRows']//a")).ToList();
            List<Game> games = new List<Game>();
            foreach (var item in gamesElements)
            {
                Game game = new Game();
                game.Name = item.FindElement(By.ClassName("tab_item_name")).Text;
                List<IWebElement> genres = item.FindElements(By.ClassName("top_tag")).ToList();
                game.Genres = new List<string>();
                game.Genres.Add(genres[0].Text);
                for (int i = 1; i < genres.Count; i++)
                {
                    var a = genres[i].Text.Split(", ");
                    game.Genres.Add(a[1]); 
                }
                var priceCollection = item.FindElements(By.ClassName("discount_final_price"));
                if (!priceCollection.Any() || priceCollection[0].Text == "Free To Play" || priceCollection[0].Text == "Free")
                {
                    game.Price = 0;
                }
                else
                {
                    var a = priceCollection[0].Text.Split('$');
                    var b = a[1].Replace(".", ",");
                    game.Price = double.Parse(b);

                }
                var sale = item.FindElements(By.ClassName("discount_pct"));
                if(!sale.Any())
                {
                    game.Sale = 0;
                }
                else
                {
                    var c = sale[0].Text.Split('-', '%');
                    game.Sale = Convert.ToInt32(c[1]);
                }
                

                games.Add(game);
            }
            return games;
        }

        public void ClickGameWithTheBiggestSale()
        {
            List<IWebElement> gamesElementsForSale = _driver.FindElements(By.XPath("//div[@id='NewReleasesRows']//a")).ToList();
            int maxSale = 0;
            int saleViewer = 0;
            IWebElement maxSaleElement = gamesElementsForSale[0];
            foreach (var item in gamesElementsForSale)
            {
                var sale = item.FindElements(By.ClassName("discount_pct"));
                if (!sale.Any())
                {
                    saleViewer = 0;
                }
                else
                {
                    var d = sale[0].Text.Split('-', '%');
                    saleViewer = Convert.ToInt32(d[1]);
                };

                if (saleViewer > maxSale)
                {
                    maxSaleElement = item;
                    maxSale = saleViewer;
                }
            }
            var clickMaxSaleElementv = maxSaleElement.FindElement(By.ClassName("tab_item_name"));
            clickMaxSaleElementv.Click();
            _wait.Until(ExpectedConditions.ElementExists(By.ClassName("apphub_AppName")));

        }

    }
}
