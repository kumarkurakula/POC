using OA.Domain.Entities;
using OA.Domain.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Persistence.Seeds
{
    public static class ProductsSeedData
    {
        public static async Task Seed(InMemoryDbContext context)
        {
            var products = new List<Product>
            {
                new()
                {
                    ProductName = "Apple",
                    UnitPrice= 200.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    CategoryId = 101,
                },
                new()
                {
                    ProductName = "Milk",
                    UnitOfMeasurement = UnitOfMeasurement.Liter,
                    CategoryId = 1001
                }
            };

            var categories = new List<Category>
            {
                new() { Id = 100, CategoryName = "Fruits and Vegetables" },
                new() { Id = 101, CategoryName = "Dairy" }
            };

            context.Product.AddRange(products);
            context.Category.AddRange(categories);

            await context.SaveChangesAsync();
        }
    }
}