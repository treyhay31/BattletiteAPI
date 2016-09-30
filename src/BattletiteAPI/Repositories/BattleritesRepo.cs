using BattletiteAPI.DataContext;
using BattletiteAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BattletiteAPI.DataContext.DBValidation;

namespace BattletiteAPI.Repositories
{
    public class BattleritesRepo : IRepo<Battlerite, Battlerite>
    {
        private readonly IMongoCollection<Battlerite> _battlerites;
        
        public BattleritesRepo()
        {
            _battlerites = new BattletiteContext().Battlerites;
        }

        public async Task<Battlerite> Create(Battlerite value)
        {
            await _battlerites.InsertOneAsync(value);

            return await GetOne(value.Name);
        }

        public async Task<IEnumerable<Battlerite>> GetAll()
        {
            return await _battlerites
                .Find(new BsonDocument())
                .ToListAsync();
        }

        public async Task<Battlerite> GetOne(string id)
        {
            return await _battlerites
                .Find(NameOrIdFilter<Battlerite>(id))
                .SingleOrDefaultAsync();
        }

        public async Task<Battlerite> PartialUpdate(string id, Battlerite value)
        {
            await _battlerites.ReplaceOneAsync(NameOrIdFilter<Battlerite>(id), value);

            return await GetOne(id);
        }

        public async Task Remove(string id)
        {
            await _battlerites.DeleteOneAsync(NameOrIdFilter<Battlerite>(id));
        }

        public async Task<Battlerite> Update(string id, Battlerite value)
        {
            await _battlerites.ReplaceOneAsync(NameOrIdFilter<Battlerite>(id), value);

            return await GetOne(id);
        }
    }
}
