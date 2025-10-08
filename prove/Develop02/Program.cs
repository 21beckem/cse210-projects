using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new([]);
        Console.WriteLine();
        while (true)
        {
            Console.Clear();
            string c = journal._entries.Count.ToString().PadLeft(3);
            Console.Write(String.Join("\n", [
                "o------------------------------------",
                "o                                   |",
                "o            Journal App            |",
                "o                                   |",
               $"o   Total Entries: {c}              |",
                "o                                   |",
                "o                                   |",
                "o  Select a choice from the menu:   |",
                "o                                   |",
                "o  (W) Write a new entry            |",
                "o  (D) Display all entries          |",
                "o  (L) Load entries from a file     |",
                "o  (S) Save entries to a file       |",
                "o  (Q) Quit                         |",
                "o                                   |",
                "o------------------------------------",
                "",
                "Enter your choice: "
            ]));

            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice.ToLower())
            {
                case "w":
                    journal.Write();
                    break;
                case "d":
                    journal.Display();
                    break;
                case "l":
                    journal.Load();
                    break;
                case "s":
                    journal.Save();
                    break;
                case "q":
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