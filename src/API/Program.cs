using API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();
app.UseApplicationPipeline(app.Environment);

app.MapGet("/", () => "Hello World!");

app.Run();