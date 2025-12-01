using System.Reflection.PortableExecutable;

class Map
{
    private Cell[,] _cells;
    private Character _character;
    // private Inventory _inventory;

    public Map()
    {
        int sizeX = 100;
        int sizeY = 25;
        _cells = Generate2dArrayOfCells(sizeY, sizeX);

        // _character = new(sizeX/2, sizeY/2);
        _character = new(5, 5, this);
    }
    private Cell[,] Generate2dArrayOfCells(int rows, int cols)
    {
        Cell[,] myArray = new Cell[rows, cols];

        // Fill the 2D array using nested loops
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                myArray[i, j] = new Cell(j, i);
            }
        }
        return myArray;
    }
    public Cell GetCellAt(int posX, int posY)
    {
        return _cells[posY, posX];
    }

    public void DisplayAll()
    {
        Console.ResetColor();
        Console.Clear();

        // hide cursor
        Console.CursorVisible = false;
        foreach (Cell c in _cells)
        {
            c.Display();
        }
        _character.Display();
    }
    public void Display() { _character.Display(); }
    public void MoveX(int d) { _character.MoveX(d); }
    public void MoveY(int d) { _character.MoveY(d); }
}