using StoreCS.DAL.Abstract.Repository.Base;
using StoreCS.Entities;

namespace StoreCS.DAL.Abstract.Repository;

public interface IProductRepository : IGenericRepository<int, Product>
{
}
