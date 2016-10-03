using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattletiteAPI.Models
{
    public class BattleriteMeta
    {
        public List<Battlerite> RoundOne { get; set; }

        public List<Battlerite> RoundTwo { get; set; }

        public List<Battlerite> RoundThree { get; set; }

        public List<Battlerite> RoundFour { get; set; }

        public List<Battlerite> RoundFive { get; set; }
    }
}
