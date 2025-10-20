using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scrip = new(
            new Reference("John", 2, 3),
            "Jesus wept."
        );
        scrip.Display();
    }
}