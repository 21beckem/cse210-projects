class Cell
{
    private int _posX;
    private int _posY;
    private bool _canWalkOn;

    public Cell(int posX, int posY)
    {
        _posX = posX;
        _posY = posY;
    }

    public void Display()
    {
        Console.SetCursorPosition(_posX, _posY);
        Console.Write(" ");
    }

    public Item? Interact()
    {
        return null;
    }
}