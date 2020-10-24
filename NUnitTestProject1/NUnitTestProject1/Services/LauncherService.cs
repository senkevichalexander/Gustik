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
    public class LauncherService
    {
        public bool DoesFileExist(string path)
        {
            return File.Exists(path);
        }

        public bool DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return !File.Exists(path);
            }
            else
            {
                return false;
            }
        }

        public List<string> GetRowsFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("File doesn't exist");
            }

            return File.ReadAllLines(path).ToList();
        }
    }

}
