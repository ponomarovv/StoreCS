using StoreCS.DAL.Abstract.Repository;
using StoreCS.DAL.Impl.Context;
using StoreCS.DAL.Impl.Repository.Base;
using StoreCS.Entities;

namespace StoreCS.DAL.Impl.Repository;

public class ProductRepository : GenericRepository<int, Product>, IProductRepository
{
    public ProductRepository(StoreDbContext dbContext) : base(dbContext)
    {
    }
}
