using Domain.Ports.Primary;
using Domain.Ports.Secondary;
using Domain.Services;
using XMLRepository;

var builder = WebApplication.CreateBuilder(args);

string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.xml");
builder.Services.AddTransient<IRepository>(provider => new XMLProductRepository(pathFile));
builder.Services.AddTransient<IService, ProductService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products", (IService service) =>
{
    var products = service.GetAll();
    return Results.Ok(products);
}).WithName("GetProducts");

app.MapPost("/products", (string name, decimal price, IService service) =>
{
    service.Register(name, price);
    return Results.Created();
}).WithName("CreateProduct");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
