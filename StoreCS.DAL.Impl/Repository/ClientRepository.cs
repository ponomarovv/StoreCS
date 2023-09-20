using Microsoft.EntityFrameworkCore;
using StoreCS.DAL.Abstract.Repository;
using StoreCS.DAL.Impl.Context;
using StoreCS.DAL.Impl.Repository.Base;
using StoreCS.Entities;

namespace StoreCS.DAL.Impl.Repository;

public class ClientRepository : GenericRepository<int, Client>, IClientRepository
{
    private readonly StoreDbContext _dbContext;

    public ClientRepository(StoreDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<List<Client>> GetAllAsync(Func<Client, bool> predicate)
    {
        List<Client> items = await Task.FromResult(_dbContext.Clients.Include(x => x.Orders).Where(predicate).ToList());
        return items;
    }

    public override async Task<Client> GetByIdAsync(int key)
    {
        return await Task.FromResult(_dbContext.Clients
            .Include(c => c.Orders)
            .ThenInclude(o => o.OrderItems)
            .ThenInclude(oi => oi.Product.Category)
            .FirstOrDefault(c => c.Id == key));
    }
}
