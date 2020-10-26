using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SteamAutomationProject.Services
{
    public class ElementService
    {
        public List<string> GetTextListFromElements(List<IWebElement> elements)
        {
            return elements.Select(x => x.Text).ToList();
        }
    }
}
