class Item
{
    private string _name;
    private int _count;


    public Item(string name, int count = 1)
    {
        _name = name;
        _count = count;
    }
    public Item(KeyValuePair<string, int> entry)
    {
        _name = entry.Key;
        _count = entry.Value;
    }
    public string GetName() { return _name; }
    public int GetCount() { return _count; }
    public void Display()
    {
        Console.WriteLine($"   {_name}: {_count}x");
    }
}