using Domain.Ports.Primary;
using Domain.Ports.Secondary;
using Domain.Services;
using JsonRepository;
using Microsoft.Extensions.DependencyInjection;

string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.json");

var services = new ServiceCollection();

services.AddTransient<IRepository>(provider => new ProductRepository(pathFile));
services.AddTransient<IService, ProductService>();

var serviceProvider = services.BuildServiceProvider();
var productService = serviceProvider.GetService<IService>();

while (true)
{
    try
    {
        Console.WriteLine("Enter product name (or 'exit' to quit):");
        Console.WriteLine("1. Register a new product");
        Console.WriteLine("2. List all products");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");

        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.Write("Enter product name: ");
                var name = Console.ReadLine();
                Console.Write("Enter product price: ");
                decimal price = decimal.Parse(Console.ReadLine());
                productService.Register(name, price);
                break;
            case "2":
                var products = productService.GetAll();
                Console.WriteLine("Registered Products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"- {product.Name}: {product.Price:C}");
                }
                break;
            case "3":
                Console.WriteLine("Exiting the application. Goodbye!");
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }


    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
