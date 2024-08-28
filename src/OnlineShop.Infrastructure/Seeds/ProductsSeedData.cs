using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enum;
using OnlineShop.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Seeds
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
                    CategoryId = 100,
                },
                new()
                {
                    ProductName = "Avocados",
                    UnitPrice= 400.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Liter,
                    CategoryId = 100
                },
                 new()
                {
                    ProductName = "Bananas",
                    UnitPrice= 300.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    CategoryId = 100,
                },
                new()
                {
                    ProductName = "Berries",
                    UnitPrice= 20.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    CategoryId = 1001
                },
                 new()
                {
                    ProductName = "Cherries",
                    UnitPrice= 200.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    CategoryId = 101,
                },
                new()
                {
                    ProductName = "Beets",
                    UnitPrice= 20.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Kilogram,
                    CategoryId = 100
                },
                 new()
                {
                    ProductName = "Cabbage",
                    UnitPrice= 200.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Kilogram,
                    CategoryId = 100,
                },
                new()
                {
                    ProductName = "Milk",
                    UnitPrice= 200.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Liter,
                    CategoryId = 1001
                },
                 new()
                {
                    ProductName = "Honey",
                    UnitPrice= 200.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Gram,
                    CategoryId = 1001
                },
                  new()
                {
                    ProductName = "Black pepper",
                    UnitPrice= 200.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Milligram,
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