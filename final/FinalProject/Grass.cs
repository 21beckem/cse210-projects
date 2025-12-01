class Grass : Cell
{
    public Grass(int posX, int posY) : base(posX, posY) {}

    public override void Display(ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.SetCursorPosition(_posX, _posY);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("·");
    }
}