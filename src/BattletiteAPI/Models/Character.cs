using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BattletiteAPI.Helpers.Enums;

namespace BattletiteAPI.Models
{
    public class Character
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Opponent> WeakAgainst { get; set; }

        public List<Opponent> StrongAgainst { get; set; }

        public List<List<Battlerite>> Meta { get; set; }
    }

    public class Opponent
    {
        public string Id { get; set; }
        public int Votes { get; set; }
    }
}
