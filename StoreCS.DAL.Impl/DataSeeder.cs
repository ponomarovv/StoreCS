using Microsoft.Extensions.DependencyInjection;
using StoreCS.DAL.Impl.Context;
using StoreCS.Entities;

namespace StoreCS.DAL.Impl;

public static class DataSeeder
{
    public static IServiceCollection SeedData(this IServiceCollection services)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

        dbContext.Database.EnsureDeleted();

        // Create a new database
        dbContext.Database.EnsureCreated();

        // Check if the data already exists in the database
        // if (!dbContext.Clients.Any())
        {
            dbContext.ProductCategories.AddRange(
                new ProductCategory() { Name = "Category1" },
                new ProductCategory() { Name = "Category2" }
            );

            dbContext.Products.AddRange(
                new Product() { Name = "Product1", Price = 1 },
                new Product() { Name = "Product2", Price = 2 },
                new Product() { Name = "Product3", Price = 3 }
            );

            dbContext.Orders.AddRange(
                new Order()
                {
                    BoughtDate = DateTime.Now.AddDays(-1),
                    OrderItems = new List<OrderItem>()
                    {
                        new OrderItem() { Product = dbContext.Products.Where(x => x.Id == 2).FirstOrDefault(), Quantity = 3 },
                        new OrderItem() { Product = dbContext.Products.Where(x => x.Id == 3).FirstOrDefault(), Quantity = 1 },
                    }
                },
                new Order() { BoughtDate = DateTime.Now.AddDays(-10), }
            );


            dbContext.Clients.AddRange(
                new Client()
                {
                    FirstName = "FirstName1", BirthDate = DateTime.Today.AddYears(-20),
                    Orders = dbContext.Orders.Where(o => o.Id == 1).ToList()
                },
                new Client()
                {
                    FirstName = "FirstName2", BirthDate = DateTime.Today.AddYears(-30),
                    Orders = dbContext.Orders.Where(o => o.Id == 2).ToList()
                },
                new Client() { FirstName = "FirstName3", BirthDate = DateTime.Today.AddYears(-30).AddDays(2) }
            );

            // Add more seed data as needed

            dbContext.SaveChanges();
        }

        return services;
    }

    // private static double CountTotalPriceForOrder(List<OrderItem> items)
    // {
    //     double result = 0;
    //
    //     foreach (var item in items)
    //     {
    //         result += item.Quantity * item.Product.Price;
    //     }
    //
    //     return result;
    // }
}
