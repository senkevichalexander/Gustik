using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
