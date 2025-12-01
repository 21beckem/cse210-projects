class Character {
    private int _posX;
    private int _posY;
    private int _previousPosX = 0;
    private int _previousPosY = 0;
    private char _facing; // 'N', 'E', 'S', 'W'
    private Dictionary<char, int[]> _facingLookup;
    private int _previousFacingX = 0;
    private int _previousFacingY = 0;
    private Map _map;

    public Character(int posX, int posY, Map map)
    {
        _posX = posX;
        _posY = posY;
        _map = map;

        _facing = 'E';
        _facingLookup = new() {
            { 'N', [ 0, 1] },
            { 'E', [ 1, 0] },
            { 'S', [0, -1] },
            { 'W', [-1, 0] }
        };
    }

    public void Display()
    {
        // re-render last position we were at with it's cell
        if (_posX != _previousPosX || _posY != _previousPosY)
        {
            _map.GetCellAt(_previousPosX, _previousPosY).Display();
            _previousPosX = _posX;
            _previousPosY = _posY;
        }

        // re-render last position our facing cursor was at with it's cell
        int fx = _posX + _facingLookup[_facing][0];
        int fy = _posY + _facingLookup[_facing][1];
        if (fx != _previousFacingX || fy != _previousFacingY)
        {
            _map.GetCellAt(_previousFacingX, _previousFacingY).Display();
            _previousFacingX = fx;
            _previousFacingY = fy;
        }

        // render our guy
        Console.SetCursorPosition(_posX, _posY);
        Console.Write("X");

        // render our facing cursor cell with the background highlight
        Console.BackgroundColor = ConsoleColor.DarkGray;
        _map.GetCellAt(fx, fy).Display();
        Console.ResetColor();
    }
    public void MoveX(int dist)
    {
        if (dist != 1 && dist != -1) return;
        if ((dist == 1 && _facing == 'E') || (dist == -1 && _facing == 'W'))
        {
            // only move if already facing that way
            _posX += dist;
        }
        // face this way
        _facing = (dist == 1) ? 'E' : 'W';
    }
    public void MoveY(int dist)
    {
        if (dist != 1 && dist != -1) return;
        if ((dist == 1 && _facing == 'S') || (dist == -1 && _facing == 'N'))
        {
            // only move if already facing that way
            _posY -= dist;
        }
        // face this way
        _facing = (dist == 1) ? 'S' : 'N';
    }
}