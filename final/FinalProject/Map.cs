using System.Reflection.PortableExecutable;

class Map
{
    private Cell[,] _cells;
    private Character _character;
    private Inventory _inventory;
    private int _keyRowH;

    public Map()
    {
        int sizeX = 50;
        int sizeY = 17;
        _inventory = new(sizeY + 1);
        _cells = Generate2dArrayOfCells(sizeY, sizeX);

        // _character = new(sizeX/2, sizeY/2);
        _character = new(5, 5, this);

        _keyRowH = sizeY + 3;
    }
    private Cell[,] Generate2dArrayOfCells(int rows, int cols)
    {
        Cell[,] myArray = new Cell[rows, cols];

        // Fill the 2D array using nested loops
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i<=(rows/2)+1 && i>=(rows/2)-1 && j==cols-1) // gate
                {
                    myArray[i, j] = new Gate(j, i);
                }
                else if (i==0||i==rows-1 || j==0||j==cols-1) // outside fence
                {
                    myArray[i, j] = new Fence(j, i);
                }
                else if (i>3 && i<12  &&  j>5 && j< 20) // patch of farmland
                {
                    myArray[i, j] = new Farmland(j, i, _inventory);
                }
                else if (i>3 && i<8  &&  j>25 && j< 30) // pool of water
                {
                    myArray[i, j] = new Water(j, i, _inventory);
                }
                else // grass
                {
                    myArray[i, j] = new Grass(j, i);
                }
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
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ResetColor();
        Console.Clear();

        // hide cursor
        Console.CursorVisible = false;
        foreach (Cell c in _cells)
        {
            c.Display();
        }
        DisplayKeyRow();
        _character.Display();
    }
    private void DisplayKeyRow()
    {
        Console.SetCursorPosition(0, _keyRowH);
        Console.Write(string.Join("\n", [
            " 1 = Use Water. 2 = Harvest. 3 = Get Water.",
            "               WASD to move",
            "      Arrow Keys to face a direction",
            " To quit, place your player cursor over one",
            "   of the gates (White I) and press space."
        ]));
    }
    public void Display() { _character.Display(); }
    public void MoveX(int d) { _character.MoveX(d); }
    public void MoveY(int d) { _character.MoveY(d); }
    public void SetFacing(char f) { _character.SetFacing(f); }
    public void Interact(char k) { _character.Interact(k); }
}