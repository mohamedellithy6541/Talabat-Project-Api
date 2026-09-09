using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.ISpecification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; } // (where) we not need  USING TO GET ALL WE NOT NEED TO FILTER BY ANYTHING 

        public List<Expression<Func<T, object>>> Includes { get; set; }

        public BaseSpecification() // use this constructor when we want to get all the data without any filter  
        {
            Includes = new List<Expression<Func<T, object>>>();
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria) // use this constructor when we want to get all the data with filter
        {
            Criteria = criteria;
            Includes = new List<Expression<Func<T, object>>>();
        }
    }

}
