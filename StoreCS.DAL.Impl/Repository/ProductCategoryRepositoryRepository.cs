using StoreCS.DAL.Abstract.Repository;
using StoreCS.DAL.Impl.Context;
using StoreCS.DAL.Impl.Repository.Base;
using StoreCS.Entities;

namespace StoreCS.DAL.Impl.Repository;

public class ProductCategoryRepository : GenericRepository<int, ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(StoreDbContext dbContext) : base(dbContext)
    {
    }
}
