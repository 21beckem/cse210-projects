class Character {
    private int _posX;
    private int _posY;
    private int _previousPosX;
    private int _previousPosY;
    private char _facing; // 'N', 'E', 'S', 'W'
    private Map _map;

    public Character(int posX, int posY, Map map)
    {
        _posX = posX;
        _posY = posY;
        _facing = 'E';
        _map = map;
    }

    
    public void Display()
    {
        if (_posX != _previousPosX || _posY != _previousPosY)
        {
            _map.GetCellAt(_previousPosX, _previousPosY).Display();
            _previousPosX = _posX;
            _previousPosY = _posY;
        }
        Console.SetCursorPosition(_posX, _posY);
        Console.Write("X");
    }
    public void MoveX(int dist)
    {
        if (dist != 1 && dist != -1) return;
        _posX += dist;
    }
    public void MoveY(int dist)
    {
        if (dist != 1 && dist != -1) return;
        _posY -= dist;
    }
}