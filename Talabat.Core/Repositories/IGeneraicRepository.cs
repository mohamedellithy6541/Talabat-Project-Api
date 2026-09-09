using Talabat.Core.Entities;
using Talabat.Core.ISpecification;

namespace Talabat.Core.Repositories
{
    public interface IGeneraicRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GatAllAsync();
        Task<IEnumerable<T>> GatAllWithSpecAsync(ISpecification<T> spec);
        Task<T> GetById(int id);
        Task<T> GetByIdWithSpec(ISpecification<T> spec);
    }
}
