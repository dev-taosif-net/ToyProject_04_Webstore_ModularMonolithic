using Catalog.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Data;

namespace Catalog;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<CatalogDbContext>(options => options.UseNpgsql(connectionString));
        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app, IHostEnvironment env)
    {
        app.UseMigration<CatalogDbContext>();
        return app;
    }


}