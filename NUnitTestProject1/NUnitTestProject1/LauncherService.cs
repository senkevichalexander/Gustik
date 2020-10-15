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
    class LauncherService
    {
        private const string name = "SteamSetup.exe";
        private const string path = "C:\\Users\\Alexandra\\Downloads";

        public void DownloadFile()
        {
            
            if (Directory.Exists(path))
            {
                bool result = CheckFile(name);

                if (result == false)
                {
                    Assert.Fail("The file does not exist.");
                }
            }
            else
            {
                Assert.Fail("The directory or folder does not exist.");
            }            
        }

        public void DeleteFile()
        {
            var currentFile = @"C:\Users\Alexandra\Downloads\" + name;

            if (CheckFile(name))
            {
                File.Delete(currentFile);
                Assert.IsFalse(CheckFile(name));
            }
            else
            {
                Assert.Fail("The file does not exist.");
            }
        }

        private bool CheckFile(string name) 
        {
             var currentFile = @"C:\Users\Alexandra\Downloads\" + name; 
            if (File.Exists(currentFile)) 
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }

    }
    
}
