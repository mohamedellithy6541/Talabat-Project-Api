using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.ISpecification;

namespace Talabat.Repository.quary_Elvalutor
{
    public static class SpecificationElvalutor<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;// we will use this query to filter and include the data
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // check if the criteria is not null then we will filter the data based on the criteria
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include)); // check if the includes is not null then we will include the related data based on the includes
            return query;
        }

    }
}
