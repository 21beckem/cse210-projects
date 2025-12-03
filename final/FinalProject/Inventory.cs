class Inventory
{
    private Dictionary<string, int> _items = new();


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
            return true;
        }
        return false;
    }

    public void Display()
    {
        Console.WriteLine("\n  Current Inventory:");
        foreach (KeyValuePair<string, int> entry in _items)
        {
            new Item(entry).Display();
        }
        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }
}