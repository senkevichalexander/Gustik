using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SteamAutomationProject
{
    public class GenrePage : MainPage
    {
        private const string gameElementXPath = "//div[@id='NewReleasesRows']//a";
        private const string gameNameCN = "tab_item_name";
        private const string gameTagsListCN = "top_tag";
        private const string priceCollectionListCN = "discount_final_price";
        private const string saleFieldCN = "discount_pct";
        private const string gameElementsForSaleXpath = "//div[@id='NewReleasesRows']//a";

        private List<Game> MapElementsToGames(List<IWebElement> gamesElements)
        {
            List<Game> games = new List<Game>();
            foreach (var item in gamesElements)
            {
                Game game = new Game
                {
                    Name = item.FindElement(By.ClassName(gameNameCN)).Text
                };

                List<IWebElement> genres = item.FindElements(By.ClassName(gameTagsListCN)).ToList();
                game.Genres = MapGenreElementsToStringList(genres);

                List<IWebElement> priceCollection = item.FindElements(By.ClassName(priceCollectionListCN)).ToList();
                game.Price = MapPriceCollectionToDouble(priceCollection);

                var sale = item.FindElements(By.ClassName(saleFieldCN));

                if (!sale.Any())
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

        private List<string> MapGenreElementsToStringList(List<IWebElement> genreElements)
        {
            List<string> genres = new List<string>
            {
                genreElements[0].Text
            };

            for (int i = 1; i < genreElements.Count; i++)
            {
                var a = genreElements[i].Text.Split(", ");
                genres.Add(a[1]);
            }

            return genres;
        }

        private double MapPriceCollectionToDouble(List<IWebElement> priceCollection)
        {
            double price;

            if (!priceCollection.Any() || priceCollection[0].Text == "Free To Play" || priceCollection[0].Text == "Free")
            {
                price = 0;
            }
            else
            {
                var a = priceCollection[0].Text.Split('$');
                var b = a[1].Replace(".", ",");
                price = double.Parse(b);

            }

            return price;
        }

        public List<Game> GetGames()
        {
            List<IWebElement> gamesElements = Driver.FindElements(By.XPath(gameElementXPath)).ToList();            

            return MapElementsToGames(gamesElements);
        }

        public void ClickGameWithTheBiggestSale()
        {
            List<IWebElement> gamesElementsForSale = Driver.FindElements(By.XPath(gameElementsForSaleXpath)).ToList();
            int maxSale = 0;
            int saleViewer = 0;
            IWebElement maxSaleElement = gamesElementsForSale[0];
            foreach (var item in gamesElementsForSale)
            {
                var sale = item.FindElements(By.ClassName(saleFieldCN));
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
            var clickMaxSaleElementv = maxSaleElement.FindElement(By.ClassName(gameNameCN));
            clickMaxSaleElementv.Click();
            WaitHelper.SetExplicitWait(Driver, By.ClassName("apphub_AppName"));

        }

    }
}
