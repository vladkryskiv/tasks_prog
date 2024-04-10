using System;


delegate double CalcDelegate(double num1, double num2, char operation);

class CalcProgram
{
   
    static double Calc(double num1, double num2, char operation)
    {
        switch (operation)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':

                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero.");
                    return 0;
                }
                return num1 / num2;
            default:
                Console.WriteLine("Error: Invalid operation.");
                return 0;
        }
    }


    public CalcDelegate funcCalc = new CalcDelegate(Calc);
}

class Program
{
    static void Main(string[] args)
    {

        CalcProgram calcProgram = new CalcProgram();

        double result1 = calcProgram.funcCalc(5, 3, '+');
        double result2 = calcProgram.funcCalc(10, 4, '-');
        double result3 = calcProgram.funcCalc(6, 2, '*');
        double result4 = calcProgram.funcCalc(8, 0, '/');


        Console.WriteLine($"Result of addition: {result1}");
        Console.WriteLine($"Result of subtraction: {result2}");
        Console.WriteLine($"Result of multiplication: {result3}");
        Console.WriteLine($"Result of division: {result4}");

        Console.ReadKey();
    }
}
