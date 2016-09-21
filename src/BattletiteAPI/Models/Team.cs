using System;
using System.Collections.Generic;
using static BattletiteAPI.Helpers.Strings;
using System.Linq;
using System.Threading.Tasks;

namespace BattletiteAPI.Models
{
    public abstract class Team
    {
        public string Id { get; set; }
        public List<Champion> Characters { get; set; }
        public int Size { get; set; }
        public int Votes { get; set; }
    }

    public class TwoManTeam : Team
    {
        public TwoManTeam()
        {
            Size = 2;
            Characters = new List<Champion>(Size);
        }

        public TwoManTeam(List<string> characterNames)
        {
            Id = CreateId(characterNames);
        }
    }

    public class ThreeManTeam : Team
    {
        public ThreeManTeam()
        {
            Size = 3;
            Characters = new List<Champion>(Size);
        }

        public ThreeManTeam(List<string> characterNames)
        {
            Id = CreateId(characterNames);
        }
    }
}
