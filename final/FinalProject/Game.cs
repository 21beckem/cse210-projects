class Game
{
    private Map _map = new();

    public void Play()
    {
        _map.DisplayAll();
        while (true)
        {
            _map.Display();

            char key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case 'w': _map.MoveY( 1); break;
                case 'd': _map.MoveX( 1); break;
                case 's': _map.MoveY(-1); break;
                case 'a': _map.MoveX(-1); break;
                case 'e': _map.DisplayInventory(); break;
                default: _map.Interact(key); break;
            }
        }
    }
}