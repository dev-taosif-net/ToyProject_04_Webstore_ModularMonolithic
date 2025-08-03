namespace API.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseApplicationPipeline(this IApplicationBuilder app, IHostEnvironment env)
    {
        app.UseCatalogModule(env);
        app.UseBasketModule(env);
        app.UseOrderingModule(env);



        return app;
    }
    
}