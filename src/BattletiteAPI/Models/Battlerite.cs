using static BattletiteAPI.Helpers.Enums;
using BattletiteAPI.Models.Abstracts;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BattletiteAPI.Models
{
    public class Battlerite : Named
    {
        public Battlerite()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public override string Name { get; set; }

        public Position Position { get; set; }

        public int Round { get; set; }

        public int Votes { get; set; }
    }
}

