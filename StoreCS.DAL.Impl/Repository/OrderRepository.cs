using StoreCS.DAL.Abstract.Repository;
using StoreCS.DAL.Impl.Context;
using StoreCS.DAL.Impl.Repository.Base;
using StoreCS.Entities;

namespace StoreCS.DAL.Impl.Repository;

public class OrderRepository : GenericRepository<int, Order>, IOrderRepository
{
    public OrderRepository(StoreDbContext dbContext) : base(dbContext)
    {
    }
}
