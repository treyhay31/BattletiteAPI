using static BattletiteAPI.Helpers.Enums;
using BattletiteAPI.Models.Abstracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BattletiteAPI.Models
{
    public class Champion : Named
    {
        public Champion()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public override string Name { get; set; }

        public string Nickname { get; set; }

        public string Description { get; set; }

        public ChampionType ChampionType { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Opponent> Counter { get; set; } = new List<Opponent>();

        public List<List<Battlerite>> Meta { get; set; } = new List<List<Battlerite>>();
    }

    public class Opponent
    {
        public string Name { get; set; }
        public int Votes { get; set; }
    }
}
