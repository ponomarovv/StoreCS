using Microsoft.EntityFrameworkCore;
using StoreCS.Entities;

namespace StoreCS.DAL.Impl.Context;

public class StoreDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    
}
