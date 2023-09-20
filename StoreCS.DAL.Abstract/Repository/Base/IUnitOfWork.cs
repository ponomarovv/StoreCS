namespace StoreCS.DAL.Abstract.Repository.Base;

public interface IUnitOfWork : IDisposable
{
    IClientRepository ClientRepository { get; }


    
    
    Task SaveChangesAsync();
}
