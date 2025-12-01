class Fence : Cell
{
    public Fence(int posX, int posY) : base(posX, posY)
    {
        _canWalkOn = false;
    }

    public override void Display(ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.SetCursorPosition(_posX, _posY);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("#");
    }
}