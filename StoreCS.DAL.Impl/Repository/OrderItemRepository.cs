using Microsoft.EntityFrameworkCore;
using StoreCS.DAL.Abstract.Repository;
using StoreCS.DAL.Impl.Context;
using StoreCS.DAL.Impl.Repository.Base;
using StoreCS.Entities;

namespace StoreCS.DAL.Impl.Repository;

public class OrderItemRepository : GenericRepository<int, OrderItem>, IOrderItemRepository
{
    private readonly StoreDbContext _dbContext;

    public OrderItemRepository(StoreDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<List<OrderItem>> GetAllAsync(Func<OrderItem, bool> predicate)
    {
        List<OrderItem> items = await Task.FromResult(_dbContext.OrderItems
            .Include(x => x.Order)
            .Include(x => x.Product)
            .Where(predicate).ToList());
        return items;
    }
}
