class Farmland : Cell
{
    private int _status = 0;
    private string[] _statusDisplay = [
        "_",
        "\u2880",
        "\u28c0",
        "\u28e0",
        "\u28f4",
        "\u28f7"
    ];
    public Farmland(int posX, int posY, Inventory i) : base(posX, posY, i) {}

    public override void Display(ConsoleColor backgroundColor = ConsoleColor.Yellow)
    {
        Console.SetCursorPosition(_posX, _posY);
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.BackgroundColor = backgroundColor;
        Console.Write(_statusDisplay[_status]);
    }
    private void UseWater()
    {
        if (_status+1 < _statusDisplay.Length && _inventory.UseItem("Water"))
        {
            _status += 1;
        }
    }
    private void Harvest()
    {
        if (_status >= _statusDisplay.Length-1)
        {
            _inventory.AddItem(new Item("Wheat"));
            _status = 0;
        }
    }
    public override void Interact(char k)
    {
        switch (k)
        {
            case '1': UseWater(); break;
            case '2': Harvest(); break;
            default: break;
        }
    }
}