class Gate : Cell
{
    public Gate(int posX, int posY) : base(posX, posY)
    {
        _canWalkOn = false;
    }

    public override void Display(ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.SetCursorPosition(_posX, _posY);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("I");
    }
    public override Item? Interact(char k)
    {
        Console.ResetColor();
        Console.Clear();
        Console.CursorVisible = true;
        Console.WriteLine("\n   Game exited successfully :) Have a nice day!");
        Environment.Exit(0);
        return null;
    }
}