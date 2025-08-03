using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Catalog;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app, IHostEnvironment env)
    {

        return app;
    }


}