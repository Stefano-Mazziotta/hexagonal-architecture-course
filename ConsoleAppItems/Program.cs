using ApplicationComponent;
using DomainComponent.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryComponent;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string connectionString = configuration.GetConnectionString("DefaultConnection");

var service = new ServiceCollection();
service.AddDbContext<ItemsDbContext>(options => options.UseSqlServer(connectionString));

service.AddTransient<IRepository, ItemRepository>();
service.AddTransient<IService, ItemService>();

var serviceProvider = service.BuildServiceProvider();
var itemService = serviceProvider.GetRequiredService<IService>();

while (true)
{
	try
	{
		Console.WriteLine("\n Select an option:");
		Console.WriteLine("1. Add Item");
		Console.WriteLine("2. Show Items");
		Console.WriteLine("3. Exit");
		Console.Write("Option: ");

		string option = Console.ReadLine();

		switch (option)
		{
			case "1":
				Console.Write("Enter item title: ");
				string title = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(title))
				{
					Console.WriteLine("Title cannot be empty. Try again.");
					continue;
				}
				await itemService.AddAsync(title);
				Console.WriteLine($"Item '{title}' added.");
				break;
			case "2":
				Console.WriteLine("Loading items...");
				var items = await itemService.GetAsync();
				Console.WriteLine("Items:");
                foreach (var item in items)
				{
					string checkedSymbol = item.IsCompleted ? "[x]" : "[ ]";
                    Console.WriteLine($"{checkedSymbol} {item.Title}");
                }
				break;
			case "3":
				Console.WriteLine("Exiting...");
				return;
			default:
				Console.WriteLine("Invalid option. Try again.");
				break;
        }
    }
	catch (Exception exception)
	{

		Console.WriteLine($"An error has been ocurred: {exception.Message}");
	}
}