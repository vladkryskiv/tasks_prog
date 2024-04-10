using System;
using System.Threading.Tasks;

public class ParallelUtils<T, TR>
{
    private readonly Func<T, T, TR> operation;
    private readonly T operand1;
    private readonly T operand2;

    public TR Result { get; private set; }

    public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2)
    {
        this.operation = operation ?? throw new ArgumentNullException(nameof(operation));
        this.operand1 = operand1;
        this.operand2 = operand2;
    }

    public void StartEvaluation()
    {
        Task.Run(() =>
        {
            Result = operation(operand1, operand2);
        });
    }

    public void Evaluate()
    {
        Task.Run(() =>
        {
            Result = operation(operand1, operand2);
        }).Wait();
    }
}
class Program
{
    static void Main(string[] args)
    {

        Func<int, int, int> addition = (a, b) => a + b;

 
        var parallelUtils = new ParallelUtils<int, int>(addition, 10, 20);

        // Start the evaluation in a parallel thread
        parallelUtils.StartEvaluation();

 
        Console.WriteLine("Evaluation started...");

    
        System.Threading.Thread.Sleep(2000);

  
        Console.WriteLine($"Result after starting evaluation: {parallelUtils.Result}");


        parallelUtils.Evaluate();

        Console.WriteLine($"Final Result after evaluation: {parallelUtils.Result}");
    }
}