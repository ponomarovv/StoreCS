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

        // Check if the data already exists in the database
        if (!dbContext.Clients.Any())
        {
            dbContext.Clients.AddRange(
                new Client() { FirstName = "FirstName1", BirthDate = DateTime.Today.AddYears(-20) },
                new Client() { FirstName = "FirstName2", BirthDate = DateTime.Today.AddYears(-30) },
                new Client() { FirstName = "FirstName3", BirthDate = DateTime.Today.AddYears(-30).AddDays(2) }
            );

            // Add more seed data as needed

            dbContext.SaveChanges();
        }

        return services;
    }
}
