using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.ISpecification;
using Talabat.Core.Repositories;
using Talabat.Repository.Data;
using Talabat.Repository.quary_Elvalutor;

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

        public async Task<IEnumerable<T>> GatAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetById(int id)
            => await _storeContext.Set<T>().FindAsync(id);

        public Task<T> GetByIdWithSpec(ISpecification<T> spec)
        {
            return ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationElvalutor<T>.GetQuery(_storeContext.Set<T>().AsQueryable(), spec);
        }

    }
}
