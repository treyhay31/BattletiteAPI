using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattletiteAPI.Repositories
{
    public interface IRepo<TOut, TIn>
    {
        Task<IEnumerable<TOut>> GetAll();
        Task<TOut> GetOne(string id);
        Task<TOut> Create(TIn value);
        Task<TOut> Update(string id, TIn value);
        Task<TOut> PartialUpdate(string id, TIn value);
        Task Remove(string id);
    }
}
