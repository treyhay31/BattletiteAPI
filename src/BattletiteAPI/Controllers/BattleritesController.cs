using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BattletiteAPI.DataContext;
using BattletiteAPI.Models;
using MongoDB.Driver;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BattletiteAPI.Controllers
{
    [Route("api/battlerites")]
    public class BattleritesController : Controller
    {
        private readonly IMongoCollection<Battlerite> battlerites;
        private readonly FilterDefinition<Battlerite> _filter = FilterDefinition<Battlerite>.Empty;

        public BattleritesController()
        {
            var context = new BattletiteContext();
            battlerites = context.Battlerites;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Battlerite>> Get()
        {
            return await battlerites.Find(_filter).ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Battlerite> Get(string id)
        {
            var filter = Builders<Battlerite>.Filter.Eq("_id", new ObjectId(id));

            return await battlerites.Find(filter).SingleOrDefaultAsync();
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Battlerite value)
        {
            await battlerites.InsertOneAsync(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]Battlerite value)
        {
            var filter = Builders<Battlerite>.Filter.Eq("_id", new ObjectId(id));

            await battlerites.ReplaceOneAsync(filter, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var filter = Builders<Battlerite>.Filter.Eq("_id", new ObjectId(id));

            await battlerites.DeleteOneAsync(filter);
        }
    }
}
