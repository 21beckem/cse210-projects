class Inventory
{
    private Dictionary<string, int> _items = new();
    private int _rowNum;

    public Inventory() {}
    public Inventory(int rowNum)
    {
        _rowNum = rowNum;
    }


    public void AddItem(Item? item)
    {
        if (item == null) return;
        if (_items.ContainsKey(item.GetName()))
        {
            _items[item.GetName()] += item.GetCount();
        }
        else
        {
            _items.Add(item.GetName(), item.GetCount());
        }
        Display();
    }
    public bool UseItem(string thisItemName)
    {
        if (_items.ContainsKey(thisItemName))
        {
            _items[thisItemName] -= 1;
            if (_items[thisItemName] < 1)
            {
                _items.Remove(thisItemName);
            }
            Display();
            return true;
        }
        return false;
    }

    private int _lastDisplayStrLength = 0;
    private void Display()
    {
        Console.SetCursorPosition(0, _rowNum);
        string myString = string.Join(", ",
            _items.Select(item => $"{item.Key}: {item.Value}x")
        );

        int afterLength = Math.Max(0, _lastDisplayStrLength - myString.Length);
        Console.Write(" " + myString + new string(' ', afterLength));
        _lastDisplayStrLength = myString.Length;
    }
}