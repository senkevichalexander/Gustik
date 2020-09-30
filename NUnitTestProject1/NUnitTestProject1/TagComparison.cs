using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Runtime.InteropServices;

namespace NUnitTestProject1
{
    class TagComparison
    {
        private readonly IWebDriver _driver;
        public TagComparison(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool CompareLists()
        {
            string textFile = @"C:\Users\Alexandra\Downloads\Gustik.txt";
            List<string> lines = File.ReadAllLines(textFile).ToList();
            List<IWebElement> eles1 = _driver.FindElements(By.XPath("//div[div[text()='Browse by genre']]//a")).ToList();
            var texts = eles1.Select(x => x.Text).ToList();
            var result = true;

            foreach (var item in lines)
            {
                if (!texts.Any(x => x == item))
                {
                    result = false;
                }
            }

            return result;

        }
    }
}
