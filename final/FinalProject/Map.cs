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
        _character = new(2, 2);
    }
    private Cell[,] Generate2dArrayOfCells(int rows, int cols)
    {
        Cell[,] myArray = new Cell[rows, cols];

        // Fill the 2D array using nested loops
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                myArray[i, j] = new Cell();
            }
        }
        return myArray;
    }

    public void Display()
    {
        Console.Clear();

        // hide cursor
        bool cursorVisibleReset = Console.CursorVisible;
        Console.CursorVisible = false;

        // get position of interaction


        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                if (_character.AreYouHere(j,i))
                {
                    _character.Display();
                }
                else
                {
                    _cells[i, j].Display();
                }
            }
            Console.WriteLine();
        }
        Console.ResetColor();
        Console.CursorVisible = cursorVisibleReset;
    }
    public void MoveX(int d) { _character.MoveX(d); }
    public void MoveY(int d) { _character.MoveY(d); }
}