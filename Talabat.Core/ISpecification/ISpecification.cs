using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.ISpecification
{
    public interface ISpecification<T> where T : BaseEntity
    {
        // we need two prop siginature to filter and include the data

        public Expression<Func<T, bool>> Criteria { get; set; }  // USING TO GET ALL WE NOT NEED TO FILTER BY ANYTHING 

        public List<Expression<Func<T, object>>> Includes { get; set; }
    }
}
