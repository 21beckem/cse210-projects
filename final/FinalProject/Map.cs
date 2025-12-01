using System.Reflection.PortableExecutable;

class Map
{
    private Cell[,] _cells;
    // private Character _character;
    // private Inventory _inventory;

    public Map()
    {
        _cells = Generate2dArrayOfCells(25, 100);
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
        bool cursorVisibleReset = Console.CursorVisible;
        Console.CursorVisible = false;
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                _cells[i, j].Display();
            }
            Console.WriteLine();
        }
        Console.ResetColor();
        Console.CursorVisible = cursorVisibleReset;
    }
}