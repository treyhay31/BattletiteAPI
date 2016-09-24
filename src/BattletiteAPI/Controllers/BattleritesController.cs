using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BattletiteAPI.DataContext;
using BattletiteAPI.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using static BattletiteAPI.DataContext.DBValidation;

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
            return await battlerites
                .Find(new BsonDocument())
                .ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Battlerite> Get(string id)
        {
            return await battlerites
                .Find(NameOrIdFilter<Battlerite>(id))
                .SingleOrDefaultAsync();
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
            await battlerites.ReplaceOneAsync(NameOrIdFilter<Battlerite>(id), value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await battlerites.DeleteOneAsync(NameOrIdFilter<Battlerite>(id));
        }
    }
}
