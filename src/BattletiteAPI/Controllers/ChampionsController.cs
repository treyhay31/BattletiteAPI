using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using BattletiteAPI.Models;
using BattletiteAPI.DataContext;
using MongoDB.Bson;
using static BattletiteAPI.DataContext.DBValidation;
using System.Linq;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BattletiteAPI.Controllers
{
    [Route("api/champions")]
    public class ChampionsController : Controller
    {
        private readonly IMongoCollection<Champion> champions;
        private readonly FilterDefinition<Champion> _filter = FilterDefinition<Champion>.Empty;

        public ChampionsController()
        {
            var context = new BattletiteContext();
            champions = context.Champions;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Champion>> Get()
        {
            return await champions
                .Find(new BsonDocument())
                .ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Champion> Get(string id)
        {
            return await champions
                .Find(NameOrIdFilter<Champion>(id))
                .SingleOrDefaultAsync();
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Champion value)
        {
            await champions.InsertOneAsync(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]Champion value)
        {
            await champions.ReplaceOneAsync(NameOrIdFilter<Champion>(id), value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await champions.DeleteOneAsync(NameOrIdFilter<Champion>(id));
        }
    }
}
