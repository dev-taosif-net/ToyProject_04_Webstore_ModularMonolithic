namespace API.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseApplicationPipeline(this IApplicationBuilder app, IHostEnvironment env)
    {

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCatalogModule(env);
        app.UseBasketModule(env);
        app.UseOrderingModule(env);



        return app;
    }
    
}