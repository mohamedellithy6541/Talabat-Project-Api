using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Repository.Data;

namespace Talabat.Repository.Repository
{
    public class GeneraicRepository<T> : IGeneraicRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _storeContext;

        public GeneraicRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<IEnumerable<T>> GatAllAsync()
            => await _storeContext.Set<T>().ToListAsync();


        public async Task<T> GetById(int id)
            => await _storeContext.Set<T>().FindAsync(id);



    }
}
