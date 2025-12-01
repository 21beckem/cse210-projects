class Game
{
    private Map _map = new();

    public void Play()
    {
        while (true)
        {
            _map.Display();
            
            char key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case 'w':
                    // move up
                    break;
                default:
                    break;
            }
        }
    }
}