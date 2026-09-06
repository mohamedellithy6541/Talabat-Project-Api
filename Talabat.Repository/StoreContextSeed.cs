using System.Text.Json;
using Talabat.Core.Entities;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.productBrands.Any())
            {
                var productBrandsjson = File.ReadAllText("../Talabat.Repository/Data/SeedData/brands.json");
                var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsjson);
                if (productBrands != null && productBrands.Count > 0)
                {
                    foreach (var brand in productBrands)
                    {
                        await context.productBrands.AddAsync(brand);
                    }
                    await context.SaveChangesAsync();
                }
            }
            if (!context.productTypes.Any())
            {
                var productTypesjson = File.ReadAllText("../Talabat.Repository/Data/SeedData/types.json");
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesjson);
                if (productTypes != null && productTypes.Count > 0)
                {
                    foreach (var type in productTypes)
                    {
                        await context.productTypes.AddAsync(type);
                    }
                    await context.SaveChangesAsync();

                }
            }

            if (!context.Products.Any())
            {
                var productsjson = File.ReadAllText("../Talabat.Repository/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsjson);
                if (products != null && products.Count > 0)
                {
                    foreach (var product in products)
                    {
                        await context.Products.AddAsync(product);
                    }
                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
