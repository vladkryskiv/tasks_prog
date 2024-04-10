using System;

public class MyAccessModifiers
{
    private int birthYear; 
    protected string personalInfo;
    internal string IdNumber; 

 
    public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
    {
        this.birthYear = birthYear;
        this.IdNumber = idNumber;
        this.personalInfo = personalInfo;
    }

    public int Age
    {
        get
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - birthYear;
        }
    }

    private static byte averageMiddleAge = 50;


    public string Name { get; set; }

  
    public string NickName { get; internal set; }

    protected internal void HasLivedHalfOfLife()
    {
        Console.WriteLine("Half of life has been lived.");
    }


    public static bool operator ==(MyAccessModifiers obj1, MyAccessModifiers obj2)
    {
        if (obj1 is null || obj2 is null)
            return false;
        
        return obj1.Name == obj2.Name && obj1.Age == obj2.Age && obj1.personalInfo == obj2.personalInfo;
    }


    public static bool operator !=(MyAccessModifiers obj1, MyAccessModifiers obj2)
    {
        return !(obj1 == obj2);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is MyAccessModifiers))
            return false;

        MyAccessModifiers other = (MyAccessModifiers)obj;
        return this == other;
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age, personalInfo);
    }
}

class Program
{
    static void Main(string[] args)
    {

        MyAccessModifiers instance = new MyAccessModifiers(1990, "ID12345", "John Doe");
        
 
        instance.Name = "John";
        instance.NickName = "Johnny";

 
        Console.WriteLine($"Name: {instance.Name}");
        Console.WriteLine($"NickName: {instance.NickName}");
        Console.WriteLine($"Age: {instance.Age}");
        instance.HasLivedHalfOfLife();


        MyAccessModifiers instance2 = new MyAccessModifiers(1990, "ID12345", "John Doe");
        Console.WriteLine($"Are instances equal? {instance == instance2}");
    }
}
