class Game
{
    private Map _map = new();

    public void Play()
    {
        _map.DisplayAll();
        while (true)
        {
            _map.Display();

            ConsoleKeyInfo k = Console.ReadKey(true);

            if (k.Key == ConsoleKey.W)      _map.MoveY( 1);
            else if (k.Key == ConsoleKey.D) _map.MoveX( 1);
            else if (k.Key == ConsoleKey.S) _map.MoveY(-1);
            else if (k.Key == ConsoleKey.A) _map.MoveX(-1);
            else if (k.Key == ConsoleKey.UpArrow)    _map.SetFacing('S');
            else if (k.Key == ConsoleKey.RightArrow) _map.SetFacing('E');
            else if (k.Key == ConsoleKey.DownArrow)  _map.SetFacing('N');
            else if (k.Key == ConsoleKey.LeftArrow)  _map.SetFacing('W');
            else _map.Interact(k.KeyChar);
        }
    }
}