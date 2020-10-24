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
    public class ComparisonService
    {
        public bool CompareLists(List<string> firstList, List<string> secondList)
        {
            var result = false;

            foreach (var item in secondList)
            {
                if (firstList.Any(x => x == item))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
