class Scripture
{
    private Reference _ref;
    private List<Word> _words;
    private List<int> _visibleIndexes;

    public Scripture(Reference refer, string wholeText)
    {
        _ref = refer;
        _visibleIndexes = new();
        _words = wholeText
                    .Split(" ")
                    .Select((string w, int i) =>
                    {
                        _visibleIndexes.Add(i);
                        return new Word(w);
                    })
                    .ToList();
    }
    public void Display()
    {
        _ref.Display();
        foreach (Word w in _words)
        {
            w.Display();
        }
        Console.WriteLine("\nVisible Indexes");
        foreach (int i in _visibleIndexes)
        {
            Console.WriteLine(i);
        }
    }
    public bool Hide(int numToHide)
    {
        if (_visibleIndexes.Count == 0)
        {
            return false;
        }
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(0, _visibleIndexes.Count);
        Console.WriteLine("visible count: " + _visibleIndexes.Count);
        Console.WriteLine("magicNumber:" + magicNumber);
        _words[ _visibleIndexes[magicNumber] ].SetIsHidden(true);
        _visibleIndexes.RemoveAt(magicNumber);
        return true;
    }
}