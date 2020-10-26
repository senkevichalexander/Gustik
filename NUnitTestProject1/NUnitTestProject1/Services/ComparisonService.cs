using System.Collections.Generic;
using System.Linq;

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
