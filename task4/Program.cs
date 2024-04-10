using System;


interface ISwimmable
{

    void Swim()
    {
        Console.WriteLine("I can swim!");
    }
}

// Define an interface IFlyable
interface IFlyable
{

    int MaxHeight { get; }


    void Fly()
    {
        Console.WriteLine($"I can fly at {MaxHeight} meters height!");
    }
}


interface IRunnable
{

    int MaxSpeed { get; }


    void Run()
    {
        Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
    }
}


class Animal : ISwimmable, IFlyable, IRunnable
{

    public int MaxHeight => 100;
    public int MaxSpeed => 50;

    public void Swim()
    {
        Console.WriteLine("I can swim!");
    }

    public void Fly()
    {
        Console.WriteLine($"I can fly at {MaxHeight} meters height!");
    }

    public void Run()
    {
        Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
    }
}

class Program
{
    static void Main(string[] args)
    {

        var animal = new Animal();


        animal.Swim();
        animal.Fly();
        animal.Run();
    }
}
