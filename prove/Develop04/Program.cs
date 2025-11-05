using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Chat with a specialist");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            string key = Console.ReadLine();
            if (key == "1")
            {
                BreathingActivity act = new();
                act.Start();
            }
            else if (key == "2")
            {
                ReflectionActivity act = new();
                act.Start();
            }
            else if (key == "3")
            {
                ListingActivity act = new();
                act.Start();
            }
            else if (key == "4")
            {
                Specialist spec = new();
                spec.Chat();
            }
            else if (key == "5")
            {
                break;
            }
        }
    }
}