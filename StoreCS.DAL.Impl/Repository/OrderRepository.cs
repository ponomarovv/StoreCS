using Microsoft.EntityFrameworkCore;
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
    
    public override async Task<List<Order>> GetAllAsync(Func<Order, bool> predicate)
    {
        List<Order> items = await Task.FromResult( _context.Orders.Include(x=>x.OrderItems).Where(predicate).ToList());
        return items;
    }
}
