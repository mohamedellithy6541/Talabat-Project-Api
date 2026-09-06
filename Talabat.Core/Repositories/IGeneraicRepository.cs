using Talabat.Core.Entities;

namespace Talabat.Core.Repositories
{
    public interface IGeneraicRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GatAllAsync();
        Task<T> GetById(int id);
    }
}
