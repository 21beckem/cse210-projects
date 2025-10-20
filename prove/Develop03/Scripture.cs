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
    }
}