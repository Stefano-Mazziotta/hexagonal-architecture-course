using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddTransient<IRepository<string>, NamesUnique>();
services.AddTransient<MySystem>();

var serviceProvider = services.BuildServiceProvider();
var mySystem = serviceProvider.GetRequiredService<MySystem>();
mySystem.Run();


// Domain layer
// Interfaces

public interface IRepository<T>
{
    void Save(T item);
    IEnumerable<T> GetAll();
}

// Data layer
// Names component
public class Names: IRepository<string>
{
    private readonly List<string> names = new();

    public void Save(string name)
    {
        names.Add(name);
    }

    public IEnumerable<string> GetAll() => names;
}

public class NamesUnique: IRepository<string>
{
    private readonly HashSet<string> names = new();

    public void Save(string name)
    {
        names.Add(name);
    }

    public IEnumerable<string> GetAll() => names;
}

// Presentation layer
// MySystem component

public class MySystem
{
    private IRepository<string> repository;

    public MySystem(IRepository<string> repository)
    {
        this.repository = repository;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n Select an option:");
            Console.WriteLine("1. Add Name");
            Console.WriteLine("2. Show Names");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name cannot be empty. Try again.");
                        continue;
                    }
                    repository.Save(name);
                    Console.WriteLine($"Name '{name}' saved.");
                    break;
                case "2":
                    Console.WriteLine("Names:");
                    foreach (var currentName in repository.GetAll())
                    {
                        Console.WriteLine(currentName);
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
    }
}