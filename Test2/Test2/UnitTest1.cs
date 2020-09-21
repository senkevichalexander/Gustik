using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Test2
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string Xiaomi = "Xiaomi";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.onliner.by/");
            Thread.Sleep(2000);
            IWebElement ele = driver.FindElement(By.ClassName("fast-search__input"));
            Thread.Sleep(2000);
            ele.SendKeys(Xiaomi);
            Thread.Sleep(3000);
            var a = driver.FindElement(By.Id("fast-search-modal"));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@src='/sdapi/catalog/search/iframe']")));
            List<IWebElement> eles = driver.FindElements(By.XPath("//li[@class='search__result']")).ToList();
            if (!eles.Any())
            {
                Console.WriteLine("there are no telephones");

            }
            else
            {
                eles[0].Click();
                Thread.Sleep(4000);
                driver.SwitchTo().DefaultContent();
                ele = driver.FindElement(By.ClassName("product-aside__compare"));
                ele.Click();
                Thread.Sleep(4000);
                List<IWebElement> eles1 = driver.FindElements(By.ClassName("offers-list__item")).ToList();
                decimal min = 0;
                IWebElement elemMin = eles1[0];
                foreach (var item in eles1)
                {
                    var val = item.FindElement(By.ClassName("offers-list__description_nodecor")).Text;
                    var value = decimal.Parse(val.Split(' ')[0]);

                    if (min == 0 || value < min)
                    {
                        elemMin = item;
                        min = value;
                    }
                }
                ele = elemMin.FindElement(By.ClassName("offers-list__image"));
                ele.Click();
                Thread.Sleep(3000);
                var name = driver.FindElement(By.ClassName("sells-title")).Text;
                Console.WriteLine("название магазина - {0}", name);
            }

            driver.Close();
            Console.Write("test case ended ");
        }
    }
}