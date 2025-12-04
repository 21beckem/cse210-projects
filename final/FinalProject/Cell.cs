class Cell
{
    protected int _posX;
    protected int _posY;
    protected bool _canWalkOn = true;
    protected Inventory _inventory;

    public Cell(int posX, int posY)
    {
        _posX = posX;
        _posY = posY;
        _inventory = new();
    }
    public Cell(int posX, int posY, Inventory i)
    {
        _posX = posX;
        _posY = posY;
        _inventory = i;
    }

    public bool CanBeWalkedOn() { return _canWalkOn; }

    public virtual void Display(ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.SetCursorPosition(_posX, _posY);
        Console.BackgroundColor = backgroundColor;
        Console.Write(" ");
    }

    public virtual void Interact(char k) { }
}