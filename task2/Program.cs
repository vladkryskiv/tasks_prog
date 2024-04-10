using System;
using System.Collections.Generic;
using System.Linq;


interface IAnimal
{
    int LifeDuration { get; }
    void Voice();
    void ShowInfo();
}

interface IRunnable
{
    void Run();
}

interface IFlyable
{
    void Fly();
}

interface ISwimmable
{
    void Swim();
}


class Employee
{
    internal string name;
    private DateTime hiringDate;

    public Employee(string name, DateTime hiringDate)
    {
        this.name = name;
        this.hiringDate = hiringDate;
    }

    public int Experience()
    {
        return DateTime.Now.Year - hiringDate.Year;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"{name} has {Experience()} years of experience.");
    }
}


class Developer : Employee
{
    private string programmingLanguage;

    public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
    {
        this.programmingLanguage = programmingLanguage;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"{name} is {programmingLanguage} programmer.");
    }
}


class Tester : Employee
{
    private bool isAutomation;

    public Tester(string name, DateTime hiringDate, bool isAutomation) : base(name, hiringDate)
    {
        this.isAutomation = isAutomation;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"{name} is {(isAutomation ? "automated" : "manual")} tester.");
    }
}

// Cat class
class Cat : IAnimal, IRunnable
{
    public int LifeDuration { get; } = 15;

    public void Voice()
    {
        Console.WriteLine("Meow!");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"I am a Cat and I live approximately {LifeDuration} years.");
    }

    public void Run()
    {
        Console.WriteLine("Cat is running.");
    }
}


class Eagle : IAnimal, IFlyable
{
    public int LifeDuration { get; } = 25;

    public void Voice()
    {
        Console.WriteLine("Screech!");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"I am an Eagle and I live approximately {LifeDuration} years.");
    }

    public void Fly()
    {
        Console.WriteLine("Eagle is flying.");
    }
}

// Shark class
class Shark : IAnimal, ISwimmable
{
    public int LifeDuration { get; } = 20;

    public void Voice()
    {
        Console.WriteLine("Silent!");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"I am a Shark and I live approximately {LifeDuration} years.");
    }

    public void Swim()
    {
        Console.WriteLine("Shark is swimming.");
    }
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>();
        products.Add(new Product { Name = "SmartTV", Price = 400, Category = "Electronics" });
        products.Add(new Product { Name = "Lenovo ThinkPad", Price = 1000, Category = "Electronics" });
        products.Add(new Product { Name = "Iphone", Price = 700, Category = "Electronics" });
        products.Add(new Product { Name = "Orange", Price = 2, Category = "Fruits" });
        products.Add(new Product { Name = "Banana", Price = 3, Category = "Fruits" });

        ILookup<string, Product> lookup = products.ToLookup(prod => prod.Category);
        TotalPrice(lookup);

        Console.ReadKey();
    }

    static void TotalPrice(ILookup<string, Product> lookup)
    {
        foreach (var categoryGroup in lookup)
        {
            double totalPriceForCategory = categoryGroup.Sum(p => p.Price);
            Console.WriteLine($"{categoryGroup.Key}: {totalPriceForCategory}");

            foreach (var product in categoryGroup)
            {
                Console.WriteLine($"{product.Name} {product.Price}");
            }
        }
    }
}
