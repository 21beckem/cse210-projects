class Water : Cell
{
    public Water(int posX, int posY, Inventory i) : base(posX, posY, i)
    {
        _canWalkOn = false;
    }

    public override void Display(ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Console.SetCursorPosition(_posX, _posY);
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("\u224b");
    }
    public override void Interact(char k)
    {
        if (k == '3')
            _inventory.AddItem( new Item("Water") );
    }
}