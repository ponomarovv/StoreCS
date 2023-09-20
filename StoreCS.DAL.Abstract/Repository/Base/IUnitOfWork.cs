namespace StoreCS.DAL.Abstract.Repository.Base;

public interface IUnitOfWork : IDisposable
{
    IClientRepository ClientRepository { get; }
    IOrderRepository OrderRepository { get; }
    IProductRepository ProductRepository { get; }
    IProductCategoryRepository ProductCategoryRepository { get; }
    
    Task SaveChangesAsync();
}
