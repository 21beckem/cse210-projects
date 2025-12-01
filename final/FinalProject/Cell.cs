class Cell
{
    protected int _posX;
    protected int _posY;
    protected bool _canWalkOn = true;

    public Cell(int posX, int posY)
    {
        _posX = posX;
        _posY = posY;
    }

    public bool CanBeWalkedOn() { return _canWalkOn; }

    public virtual void Display(ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.SetCursorPosition(_posX, _posY);
        Console.BackgroundColor = backgroundColor;
        Console.Write(" ");
    }

    public virtual Item? Interact(char k)
    {
        return null;
    }
}