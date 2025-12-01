class Cell
{
    private int posX;
    private int posY;
    private bool _canWalkOn;


    public void Display()
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Write(" ");
    }

    public Item? Interact()
    {
        return null;
    }
}