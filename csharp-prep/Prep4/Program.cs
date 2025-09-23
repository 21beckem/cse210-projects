using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        int userNumber;
        do
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        } while (userNumber != 0);

        List<int> positiveNumbers = numbers.FindAll(item => item > 0);

        Console.WriteLine("The sum is: " + numbers.Sum());
        Console.WriteLine("The average is: " + numbers.Average());
        Console.WriteLine("The largest number is: " + numbers.Max());
        Console.WriteLine("The smallest positive number is: " + positiveNumbers.Min());

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}