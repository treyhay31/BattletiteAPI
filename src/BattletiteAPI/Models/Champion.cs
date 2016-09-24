using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BattletiteAPI.Helpers.Enums;

namespace BattletiteAPI.Models
{
    public class Champion
    {
        public Champion()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Opponent> WeakAgainst { get; set; } = new List<Opponent>();

        public List<Opponent> StrongAgainst { get; set; } = new List<Opponent>();

        public List<List<Battlerite>> Meta { get; set; } = new List<List<Battlerite>>();
    }

    public class Opponent
    {
        public string Name { get; set; }
        public int Votes { get; set; }
    }
}
