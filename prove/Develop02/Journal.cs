using System.Text.Json;
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
    }
    public void Load()
    {
        Console.WriteLine("Enter the filename:");
        Console.Write("> ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            _entries = JsonSerializer.Deserialize<List<Entry>>(json);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
        Console.WriteLine();
    }
    public void Save()
    {
        Console.WriteLine("Enter the filename:");
        Console.Write("> ");
        string filename = Console.ReadLine();

        File.WriteAllText(filename, JsonSerializer.Serialize(_entries));
        Console.WriteLine();
    }
}