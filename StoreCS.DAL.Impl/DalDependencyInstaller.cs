using Microsoft.Extensions.DependencyInjection;
using StoreCS.DAL.Abstract.Repository;
using StoreCS.DAL.Abstract.Repository.Base;
using StoreCS.DAL.Impl.Repository;
using StoreCS.DAL.Impl.Repository.Base;

namespace StoreCS.DAL.Impl;

public static class DalDependencyInstaller
{
    public static void InstallRepositories(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}
