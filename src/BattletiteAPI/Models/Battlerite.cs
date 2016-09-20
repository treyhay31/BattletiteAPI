using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BattletiteAPI.Helpers.Enums;

namespace BattletiteAPI.Models
{
    public class Battlerite
    {
        public string Id { get; set; }
        public Position Position { get; set; }
        public int Round { get; set; }
        public int Votes { get; set; }
    }
}

