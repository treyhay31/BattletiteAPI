using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BattletiteAPI.Helpers.Enums;

namespace BattletiteAPI.Models
{
    public class Battlerite
    {
        public Battlerite()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string Name { get; set; }

        public Position Position { get; set; }

        public int Round { get; set; }

        public int Votes { get; set; }
    }
}

