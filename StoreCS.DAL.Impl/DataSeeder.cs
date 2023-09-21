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
        
        // Check if the database exists, and if it does, don't recreate it
        if (!dbContext.Database.EnsureCreated())
        {
            return services;
        }

        // Seed data only if the database was just created
        SeedInitialData(dbContext);

        return services;
    }

    private static void SeedInitialData(StoreDbContext dbContext)
    {
        var category1 = new ProductCategory { Name = "Category1" };
        var category2 = new ProductCategory { Name = "Category2" };

        var product1 = new Product { Name = "Product1", Price = 1, Category = category1 };
        var product2 = new Product { Name = "Product2", Price = 2, Category = category1 };
        var product3 = new Product { Name = "Product3", Price = 3, Category = category2 };

        dbContext.AddRange(
            category1,
            category2,
            product1,
            product2,
            product3
        );

        var order1 = new Order { BoughtDate = DateTime.Now.AddDays(-1) };
        var order2 = new Order { BoughtDate = DateTime.Now.AddDays(-10) };

        var orderItem1 = new OrderItem { Product = product2, Quantity = 3 };
        var orderItem2 = new OrderItem { Product = product3, Quantity = 1 };
        var orderItem3 = new OrderItem { Product = product1, Quantity = 2 };

        order1.OrderItems = new List<OrderItem> { orderItem1, orderItem2 };
        order1.TotalPrice = CountTotalPriceForOrder(order1);

        order2.OrderItems = new List<OrderItem> { orderItem3 };
        order2.TotalPrice = CountTotalPriceForOrder(order2);

        dbContext.AddRange(
            order1,
            order2
        );

        var client1 = new Client
        {
            FirstName = "FirstName1",
            BirthDate = DateTime.Today.AddYears(-20),
            Registered =  DateTime.Now.AddYears(-10),
            Orders = new List<Order> { order1 }
        };

        var client2 = new Client
        {
            FirstName = "FirstName2",
            BirthDate = DateTime.Today.AddYears(-30),
            Registered =  DateTime.Now.AddYears(-10),
            Orders = new List<Order> { order2 }
        };

        var client3 = new Client
        {
            FirstName = "FirstName3",
            BirthDate = DateTime.Today.AddYears(-30).AddDays(2),
            Registered = DateTime.Now.AddYears(-11)
        };

        dbContext.AddRange(
            client1,
            client2,
            client3
        );

        dbContext.SaveChanges();
    }
    
    // We can create another service layer and we can create an OrderService for it, but for now it is ok. I reckon.
    private static double CountTotalPriceForOrder(Order order)
    {
        double result = 0;
        foreach (var item in order.OrderItems!)
        {
            result += (double)(item.Quantity * item.Product?.Price)!;
        }

        return result;
    }
}
