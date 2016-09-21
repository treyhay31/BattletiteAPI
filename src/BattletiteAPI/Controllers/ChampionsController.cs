using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using BattletiteAPI.Models;
using BattletiteAPI.DataContext;
using MongoDB.Bson;

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
            return await champions.Find(_filter).ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Champion> Get(string id)
        {
            var filter = Builders<Champion>.Filter.Eq("_id", new ObjectId(id));

            return await champions.Find(filter).SingleOrDefaultAsync();
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
            var filter = Builders<Champion>.Filter.Eq("_id", new ObjectId(id));

            await champions.ReplaceOneAsync(filter, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var filter = Builders<Champion>.Filter.Eq("_id", new ObjectId(id));

            await champions.DeleteOneAsync(filter);
        }
    }
}
