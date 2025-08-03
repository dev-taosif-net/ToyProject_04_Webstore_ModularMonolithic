using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ordering;

public static class OrderingModule
{
    public static IServiceCollection AddOrderingModule(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }

    public static IApplicationBuilder UseOrderingModule(this IApplicationBuilder app, IHostEnvironment env)
    {

        return app;
    }

}