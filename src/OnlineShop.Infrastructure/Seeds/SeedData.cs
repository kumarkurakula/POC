using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enum;
using OnlineShop.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Seeds
{
    public static class SeedData
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
                    CategoryId = 1000,
                },
                new()
                {
                    ProductName = "Avocados",
                    UnitPrice= 400.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Liter,
                    CategoryId = 1000
                },
                 new()
                {
                    ProductName = "Bananas",
                    UnitPrice= 300.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    CategoryId = 1000,
                },
                new()
                {
                    ProductName = "Berries",
                    UnitPrice= 20.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    CategoryId = 1000
                },
                 new()
                {
                    ProductName = "Cherries",
                    UnitPrice= 200.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    CategoryId = 1000,
                },
                new()
                {
                    ProductName = "Kiwi",
                    UnitPrice= 20.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Kilogram,
                    CategoryId = 1000
                },
                 new()
                {
                    ProductName = "Grapes",
                    UnitPrice= 10.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Kilogram,
                    CategoryId = 1000
                },
                  new()
                {
                    ProductName = "Grapefruit",
                    UnitPrice= 11.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Kilogram,
                    CategoryId = 1000
                },
                 new()
                {
                    ProductName = "Beets",
                    UnitPrice= 200.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Kilogram,
                    CategoryId = 1001,
                },
                  new()
                {
                    ProductName = "Cabbage",
                    UnitPrice= 201.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Kilogram,
                    CategoryId = 1001,
                },
                  new()
                {
                    ProductName = "Cauliflower",
                    UnitPrice= 200.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Kilogram,
                    CategoryId = 1001,
                },
                  new()
                {
                    ProductName = "Celery",
                    UnitPrice= 201.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Kilogram,
                    CategoryId = 1001,
                },
                new()
                {
                    ProductName = "Milk",
                    UnitPrice= 200.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Liter,
                    CategoryId = 1003
                },
                 new()
                {
                    ProductName = "Butter",
                    UnitPrice= 200.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Liter,
                    CategoryId = 1003
                },
                 new()
                {
                    ProductName = "Feta cheese",
                    UnitPrice= 200.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Liter,
                    CategoryId = 1003
                },
                 new()
                {
                    ProductName = "Cream cheese",
                    UnitPrice= 200.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Liter,
                    CategoryId = 1003
                },
                  new()
                {
                    ProductName = "Black pepper",
                    UnitPrice= 200.4m,
                    UnitOfMeasurement = UnitOfMeasurement.Milligram,
                    CategoryId = 1007
                }
            };

            context.Product.AddRange(products);

            await context.SaveChangesAsync();
        }

        public static async Task CategorySeed(InMemoryDbContext context)
        {
            var categories = new List<Category>
            {
                new()
                {
                    Id = 1000,
                    CategoryName = "Fruits"
                },
                new()
                {
                    Id = 1001,
                    CategoryName = "Vegetables"
                },
                 new()
                {
                    Id = 1002,
                    CategoryName = "Dairy"
                },
                new()
                {
                    Id = 1003,
                    CategoryName = "Bread and baked goods"
                },
                 new()
                {
                    Id = 1004,
                    CategoryName = " Meat and fish"
                },
                new()
                {
                    Id = 1005,
                    CategoryName = "Meat alternatives"
                },
                 new()
                {
                    Id = 1006,
                    CategoryName = "Cans and jars"
                },
                new()
                {
                    Id = 1007,
                    CategoryName = "Pasta and cereals"
                }, new()
                {
                    Id = 1008,
                    CategoryName = "Sauces and condiments"
                },
                new()
                {
                    Id = 1009,
                    CategoryName = "Herbs and spices"
                },
                new()
                {
                    Id = 1010,
                    CategoryName = "Frozen foods"
                },
                new()
                {
                    Id = 1012,
                    CategoryName = "Snacks"
                },
                new()
                {
                    Id = 1013,
                    CategoryName = "Drinks"
                },
                new()
                {
                    Id = 1014,
                    CategoryName = "Household and cleaning"
                }
                ,
                new()
                {
                    Id = 1015,
                    CategoryName = "Personal care"
                },
                new()
                {
                    Id = 1016,
                    CategoryName = "Pet care"
                },
                new()
                {
                    Id = 1017,
                    CategoryName = "Baby products"
                }
            };

            context.Category.AddRange(categories);

            await context.SaveChangesAsync();
        }
    }
}