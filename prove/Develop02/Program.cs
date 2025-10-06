using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new([]);
        Console.WriteLine();
        while (true)
        {
            Console.WriteLine("Select a choice from the menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Load entries from a file");
            Console.WriteLine("4. Save entries to a file");
            Console.WriteLine("5. Quit");
            
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    journal.Write();
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    journal.Load();
                    break;
                case "4":
                    journal.Save();
                    break;
                case "5":
                    Console.WriteLine();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}