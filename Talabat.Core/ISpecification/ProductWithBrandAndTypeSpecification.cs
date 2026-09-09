using Talabat.Core.Entities;

namespace Talabat.Core.ISpecification
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductWithBrandAndTypeSpecification()
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);

        }
        public ProductWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);

        }

    }
}
