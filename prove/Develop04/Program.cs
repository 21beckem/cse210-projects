using System;

class Program
{
    static void Main(string[] args)
    {
        Activity act = new();
        Console.Write("loading... ");
        act.Loader(5);
    }
}