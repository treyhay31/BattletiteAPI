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
using BattletiteAPI.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BattletiteAPI.Controllers
{
    [Route("api/battlerites")]
    public class BattleritesController : Controller
    {
        private readonly IRepo<Battlerite, Battlerite> _battlerites;

        public BattleritesController(IRepo<Battlerite, Battlerite> battlerites)
        {
            _battlerites = battlerites;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Battlerite>> Get()
        {
            return await _battlerites.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Battlerite> Get(string id)
        {
            return await _battlerites.GetOne(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<Battlerite> Post([FromBody]Battlerite value)
        {
            return await _battlerites.Create(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<Battlerite> Put(string id, [FromBody]Battlerite value)
        {
            return await _battlerites.Update(id, value);
        }

        // PATCH api/values/5
        [HttpPatch("{id}")]
        public async Task<Battlerite> Patch(string id, [FromBody]Battlerite value)
        {
            return await _battlerites.PartialUpdate(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _battlerites.Remove(id);
        }
    }
}
