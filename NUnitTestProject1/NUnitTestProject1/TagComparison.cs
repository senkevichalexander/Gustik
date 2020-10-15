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

namespace SteamAutomationProject
{
    class TagComparison
    {
        public bool CompareLists(List<string> texts)
        {
            string textFile = @"C:\Users\Alexandra\Downloads\Gustik.txt";
            List<string> lines = File.ReadAllLines(textFile).ToList();
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
