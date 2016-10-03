using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattletiteAPI.Models
{
    public class Opponent
    {
        public string Name { get; set; }

        public int UpVotes { get; set; } = 0;

        public int DownVotes { get; set; } = 0;

        public int Votes { get { return UpVotes - DownVotes; } }

        public void UpVote()
        {
            UpVotes++;
        }

        public void DownVote()
        {
            DownVotes++;
        }
    }
}
