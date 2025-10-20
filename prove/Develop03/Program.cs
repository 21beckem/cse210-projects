using System;

class Program
{
    static void Main(string[] args)
    {
        string nextMsg = "\nPress any key to hide words";

        Scripture scrip = new(
            new Reference("Matthew", 5, 14, 16),
            "I am cool"
        );
        scrip.Display();
        Console.WriteLine(nextMsg);

        while (true)
        {
            Console.ReadLine();
            if (!scrip.Hide(1))
            {
                break;
            }
            scrip.Display();
            Console.WriteLine(nextMsg);
        }
    }
}