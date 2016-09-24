using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattletiteAPI.Models.REST
{
    public abstract class Item
    {
        public string Id { get; set; }
        public string Href { get; set; }
    }
}
