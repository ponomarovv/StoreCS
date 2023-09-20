using StoreCS.DAL.Abstract.Repository.Base;
using StoreCS.Entities;

namespace StoreCS.DAL.Abstract.Repository;

public interface IOrderItemRepository : IGenericRepository<int, OrderItem>
{
}
