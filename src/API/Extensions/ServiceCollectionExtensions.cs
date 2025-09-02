using Basket;
using Carter;
using Catalog;
using Ordering;
using Shared.Exceptions.Handler;

namespace API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddExceptionHandler<CustomExceptionHandler>();

        var catalogAssembly = typeof(CatalogModule).Assembly;
        var basketAssembly = typeof(BasketModule).Assembly;
        var orderingAssembly = typeof(OrderingModule).Assembly;

        services.AddCarterWithAssemblies(catalogAssembly, basketAssembly, orderingAssembly);

        services.AddCatalogModule(configuration);
        services.AddBasketModule(configuration);
        services.AddOrderingModule(configuration);

        return services;
    }
}