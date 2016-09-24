using BattletiteAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattletiteAPI.DataContext
{
    public class BattletiteContext
    {
        private readonly IMongoClient _client;
        public readonly IMongoDatabase _db;

        public BattletiteContext()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("battletite");
        }

        public IMongoCollection<Champion> Champions => _db.GetCollection<Champion>("champions");

        public IMongoCollection<Battlerite> Battlerites => _db.GetCollection<Battlerite>("battlerites");

        public IMongoCollection<Team> Teams => _db.GetCollection<Team>("teams");
    }
}
