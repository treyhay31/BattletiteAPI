using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattletiteAPI.Models.REST
{
    public class Collection<T> where T : Item
    {
        public string Href { get; set; }
        public List<T> Items { get; set; }
        public int Length { get; set; }
    }
}
