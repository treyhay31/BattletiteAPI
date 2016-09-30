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
    public class ChampionsRepo : IRepo<Champion, Champion>
    {
        private readonly IMongoCollection<Champion> _champs;

        public ChampionsRepo()
        {
            _champs = new BattletiteContext().Champions;
        }

        public async Task<Champion> Create(Champion value)
        {
            await _champs.InsertOneAsync(value);

            return await GetOne(value.Name);
        }

        public async Task<IEnumerable<Champion>> GetAll()
        {
            return await _champs
                .Find(new BsonDocument())
                .ToListAsync();
        }

        public async Task<Champion> GetOne(string id)
        {
            return await _champs
                .Find(NameOrIdFilter<Champion>(id))
                .SingleOrDefaultAsync();
        }

        public async Task<Champion> PartialUpdate(string id, Champion value)
        {
            await _champs.ReplaceOneAsync(NameOrIdFilter<Champion>(id), value);

            return await GetOne(id);
        }

        public async Task Remove(string id)
        {
            await _champs.DeleteOneAsync(NameOrIdFilter<Champion>(id));
        }

        public async Task<Champion> Update(string id, Champion value)
        {
            await _champs.ReplaceOneAsync(NameOrIdFilter<Champion>(id), value);

            return await GetOne(id);
        }
    }
}
