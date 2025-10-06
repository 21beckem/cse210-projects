class Journal
{
    public List<Entry> _entries = new List<Entry>();
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
            new Entry(DateTime.Now.ToShortDateString(), prompt, response)
        );
        Console.WriteLine();
    }
    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }
    public void Load()
    {
        
    }
    public void Save()
    {
        
    }
    public void Quit()
    {
        
    }
}