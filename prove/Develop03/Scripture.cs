class Scripture
{
    private Reference _ref;
    private string _wholeText;
    private List<Word> _words;
    private List<int> _visibleIndexes;

    public Scripture(Reference refer, string wholeText)
    {
        _wholeText = wholeText;
        _ref = refer;
        Reset();
    }
    public void Reset()
    {
        _visibleIndexes = new();
        _words = _wholeText
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
        Console.Clear();
        _ref.Display();
        foreach (Word w in _words)
        {
            w.Display();
        }
        Console.WriteLine();
    }
    public bool Hide(int numToHide)
    {
        // if none off the bat, return false
        if (_visibleIndexes.Count == 0)
        {
            return false;
        }
        for (int i = 0; i < numToHide; i++)
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(0, _visibleIndexes.Count);
            _words[ _visibleIndexes[magicNumber] ].SetIsHidden(true);
            _visibleIndexes.RemoveAt(magicNumber);
            
            // if none after starting, but there was at least 1 at the beginning, return true because something still changed
            if (_visibleIndexes.Count == 0)
            {
                return true;
            }
        }
        return true;
    }
}