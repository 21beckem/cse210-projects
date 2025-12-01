class Farmland : Cell
{
    private int _status = 0;
    private string[] _statusDisplay = [
        "\u2880",
        "\u28c0",
        "\u28e0",
        "\u28f4",
        "\u28f7"
    ];
    public Farmland(int posX, int posY) : base(posX, posY) {}

    public override void Display(ConsoleColor backgroundColor = ConsoleColor.Yellow)
    {
        Console.SetCursorPosition(_posX, _posY);
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.BackgroundColor = backgroundColor;
        Console.Write(_statusDisplay[_status]);
    }
    public override Item? Interact(char k)
    {
        _status += 1;
        if (_status >= _statusDisplay.Length)
        {
            _status = 0;
            return new Item();
        }
        else
        {
            return null;
        }
    }
}