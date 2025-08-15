using API.Extensions;
using Carter;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();
app.UseApplicationPipeline(app.Environment);
app.MapCarter();
app.MapGet("/", () => "Hello World!");

app.Run();