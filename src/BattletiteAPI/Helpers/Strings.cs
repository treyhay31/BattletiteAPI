using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattletiteAPI.Helpers
{
    public static class Strings
    {
        public static string CreateId(List<string> characterNames)
        {
            return characterNames.OrderBy(c => c).Aggregate((current, next) => current + "-" + next);
        }
    }
}
