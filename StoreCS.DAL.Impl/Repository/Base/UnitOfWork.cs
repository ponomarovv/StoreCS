using StoreCS.DAL.Abstract.Repository;
using StoreCS.DAL.Abstract.Repository.Base;
using StoreCS.DAL.Impl.Context;

namespace StoreCS.DAL.Impl.Repository.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly StoreDbContext _context;

    public IClientRepository ClientRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IProductCategoryRepository ProductCategoryRepository { get; }

    public UnitOfWork(StoreDbContext context, 
        IClientRepository clientRepository, IOrderRepository orderRepository, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
    {
        _context = context;

        ClientRepository = clientRepository;
        OrderRepository = orderRepository;
        ProductRepository = productRepository;
        ProductCategoryRepository = productCategoryRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            this._disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
