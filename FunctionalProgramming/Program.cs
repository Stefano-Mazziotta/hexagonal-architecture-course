

using ObjectOrientedProgramming.Bussiness;

DateTime TomorrowPure(DateTime date) 
{
    return date.AddDays(1);
}
var myF = TomorrowPure;

Console.WriteLine(myF(new DateTime(2023, 10, 1)));

Console.WriteLine(TomorrowPure(new DateTime()));

Beer beer = new Beer("IPA", "Ale", 5.5, 10);

Action<string> show = Console.WriteLine;
show("Hola");

Action<string> hi = name => Console.WriteLine($"Hola {name}");

hi("Mundo");

// Action<int, int> add = (a, b) => show((a + b).ToString());
Func<int,int,int> add = (a, b) => a + b;

show(add(5, 6).ToString());


List <int> MyFilter(List<int> elements, Predicate<int> condition)
{
    var result = new List<int>();

    foreach(var element in elements)
    {
        if (condition(element))
        {
            result.Add(element);
        }
    }

    return result;
}

Predicate<int> isEven = number => number % 2 == 0;
Predicate<int> greatherThanFive = number => number > 5;

List<int> numbers = [1,2,3,4,5,6,7,8,9,10];
var numbers2 = MyFilter(numbers, isEven);

foreach(var number in numbers2)
{
    Console.WriteLine(number);
}