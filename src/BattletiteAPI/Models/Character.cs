using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattletiteAPI.Models
{
    public class Character
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public List<Tags> Tags { get; set; }

        public List<Character> WeakAgainst { get; set; }

        public List<Character> StrongAgainst { get; set; }

        public List<List<Battlerite>> Meta { get; set; }
    }

    public enum Tags
    {
        Tank,
        Support,
        Damage,
        Melee,
        Ranged
    }
}
