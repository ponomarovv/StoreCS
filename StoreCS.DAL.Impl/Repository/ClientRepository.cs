using StoreCS.DAL.Abstract.Repository;
using StoreCS.DAL.Impl.Context;
using StoreCS.DAL.Impl.Repository.Base;
using StoreCS.Entities;

namespace StoreCS.DAL.Impl.Repository;

public class ClientRepository : GenericRepository<int, Client>, IClientRepository
{
    public ClientRepository(StoreDbContext dbContext) : base(dbContext)
    {
    }
}
