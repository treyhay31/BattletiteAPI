using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattletiteAPI.Helpers
{
    public class Enums
    {
        public enum Position
        {
            Left,   // 0 
            Center, // 1
            Right   // 2
        }

        public enum Tag
        {
            Tank,       // 0
            Support,    // 1
            Damage,     // 2
            Melee,      // 3
            Ranged      // 4
        }
    }
}
