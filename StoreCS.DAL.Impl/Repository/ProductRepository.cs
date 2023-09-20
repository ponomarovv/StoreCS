using Microsoft.EntityFrameworkCore;
using StoreCS.DAL.Abstract.Repository;
using StoreCS.DAL.Impl.Context;
using StoreCS.DAL.Impl.Repository.Base;
using StoreCS.Entities;

namespace StoreCS.DAL.Impl.Repository;

public class ProductRepository : GenericRepository<int, Product>, IProductRepository
{
    private readonly StoreDbContext _dbContext;

    public ProductRepository(StoreDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public override async Task<List<Product>> GetAllAsync(Func<Product, bool> predicate)
    {
        List<Product> items = await Task.FromResult( _dbContext.Products
            .Include(x=>x.Category)
            .Where(predicate).ToList());
        return items;
    }
}
