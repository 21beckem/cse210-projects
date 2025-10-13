using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac1 = new();
        Fraction frac2 = new(5);
        Fraction frac3 = new(1, 3);

        Console.WriteLine("Initial Values:");
        Console.WriteLine("1: " + frac1.GetTop());
        Console.WriteLine("1: " + frac1.GetBottom());
        Console.WriteLine("1: " + frac1.GetFractionString());
        Console.WriteLine("1: " + frac1.GetDecimalValue());
        Console.WriteLine();
        Console.WriteLine("2: " + frac2.GetTop());
        Console.WriteLine("2: " + frac2.GetBottom());
        Console.WriteLine("2: " + frac2.GetFractionString());
        Console.WriteLine("2: " + frac2.GetDecimalValue());
        Console.WriteLine();
        Console.WriteLine("3: " + frac3.GetTop());
        Console.WriteLine("3: " + frac3.GetBottom());
        Console.WriteLine("3: " + frac3.GetFractionString());
        Console.WriteLine("3: " + frac3.GetDecimalValue());

        Console.WriteLine();
        Console.WriteLine("Changing Values");
        Console.WriteLine();

        frac1.SetTop(frac1.GetBottom() * 2); // this is just to change the values
        frac1.SetBottom(19);
        frac2.SetTop(frac2.GetBottom() * 2);
        frac2.SetBottom(19);
        frac3.SetTop(frac3.GetBottom() * 2);
        frac3.SetBottom(19);

        
        Console.WriteLine("After Changes:");
        Console.WriteLine("1: " + frac1.GetTop());
        Console.WriteLine("1: " + frac1.GetBottom());
        Console.WriteLine("1: " + frac1.GetFractionString());
        Console.WriteLine("1: " + frac1.GetDecimalValue());
        Console.WriteLine();
        Console.WriteLine("2: " + frac2.GetTop());
        Console.WriteLine("2: " + frac2.GetBottom());
        Console.WriteLine("2: " + frac2.GetFractionString());
        Console.WriteLine("2: " + frac2.GetDecimalValue());
        Console.WriteLine();
        Console.WriteLine("3: " + frac3.GetTop());
        Console.WriteLine("3: " + frac3.GetBottom());
        Console.WriteLine("3: " + frac3.GetFractionString());
        Console.WriteLine("3: " + frac3.GetDecimalValue());
    }
}