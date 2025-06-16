using ObjectOrientedProgramming.Bussiness;

Beer erdingerBeer = new Beer("Erdinger", "Weissbier", 5.3, 10);
var delirium = new ExpiringBeer("Delirium Tremens", "Belgian Strong Ale", 8.5, new DateTime(2024, 12, 31));

Console.WriteLine("Beer Information: " + delirium.GetName());

var elements = new Collection<int>(3);
elements.Add(1);
elements.Add(2);
elements.Add(3);

foreach(var element in elements.Get())
{
    Console.WriteLine(element);
}