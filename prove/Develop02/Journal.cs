class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public Journal(List<Entry> entries)
    {
        _entries = entries;
    }
    public List<string> _promptOptions = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    ];

    public void Write()
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, _promptOptions.Count);
        string prompt = _promptOptions[magicNumber];

        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        _entries.Add(
            new Entry(prompt, response)
        );
        Console.WriteLine();
        Console.WriteLine("Saved! Returning to main menu...");
        Thread.Sleep(1000);
    }
    public void Display()
    {
        if (_entries.Count > 0)
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Your journal is currently empty.");
            Console.WriteLine();
        }
        Console.WriteLine("Press any key to go back to the main menu...");
        Console.ReadKey();
    }
    public void Load()
    {
        Console.WriteLine("Enter the filename:");
        Console.Write("> ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                Entry entry = Entry.Parse(line);
                _entries.Add(entry);
            }
            Console.WriteLine("Journal Loaded! Returning to main menu...");
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("File not found. Returning to main menu...");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
    public void Save()
    {
        Console.WriteLine("Enter the filename:");
        Console.Write("> ");
        string filename = Console.ReadLine();

        string output = "";
        foreach (Entry entry in _entries)
        {
            output += entry.Stringify() + "\n";
        }
        File.WriteAllText(filename, output);
        Console.WriteLine();
        Console.WriteLine("Journal Saved! Returning to main menu...");
        Thread.Sleep(1000);
    }
}