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
using BattletiteAPI.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BattletiteAPI.Controllers
{
    [Route("api/champions")]
    public class ChampionsController : Controller
    {
        private readonly IRepo<Champion, Champion> _champs;

        public ChampionsController(IRepo<Champion, Champion> champs)
        {
            _champs = champs;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Champion>> Get()
        {
            return await _champs.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Champion> Get(string id)
        {
            return await _champs.GetOne(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<Champion> Post([FromBody]Champion value)
        {
            return await _champs.Create(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<Champion> Put(string id, [FromBody]Champion value)
        {
            return await _champs.Update(id, value);
        }

        // PATCH api/values/5
        [HttpPatch("{id}")]
        public async Task<Champion> Patch(string id, [FromBody]Champion value)
        {
            return await _champs.PartialUpdate(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _champs.Remove(id);
        }
    }
}
