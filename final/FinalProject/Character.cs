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
    private ConsoleColor _facingCursorColor = ConsoleColor.DarkGray;

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
        _map.GetCellAt(_previousPosX, _previousPosY).Display();
        _previousPosX = _posX;
        _previousPosY = _posY;

        // re-render last position our facing cursor was at with it's cell
        int fx = _posX + _facingLookup[_facing][0];
        int fy = _posY + _facingLookup[_facing][1];
        _map.GetCellAt(_previousFacingX, _previousFacingY).Display();
        _previousFacingX = fx;
        _previousFacingY = fy;

        // render our guy
        Console.SetCursorPosition(_posX, _posY);
        Console.ResetColor();
        Console.Write("@");

        // render our facing cursor cell with the background highlight
        Console.BackgroundColor = _facingCursorColor;
        _map.GetCellAt(fx, fy).Display(_facingCursorColor);
        Console.ResetColor();
    }
    private bool CanCellBeWalkedOnAt(int posX, int posY)
    {
        return _map.GetCellAt(posX, posY).CanBeWalkedOn();
    }
    public void MoveX(int dist)
    {
        if (dist != 1 && dist != -1) return;
        if ((dist == 1 && _facing == 'E') || (dist == -1 && _facing == 'W'))
        {
            // only move if already facing that way
            if (CanCellBeWalkedOnAt(_posX+dist, _posY))
            {
                // only move if I can walk there.
                _posX += dist;
            }
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
            if (CanCellBeWalkedOnAt(_posX, _posY-dist))
            {
                // only move if I can walk there.
                _posY -= dist;
            }
        }
        // face this way
        _facing = (dist == 1) ? 'S' : 'N';
    }
    public void Interact(char k)
    {
        int fx = _posX + _facingLookup[_facing][0];
        int fy = _posY + _facingLookup[_facing][1];
        Cell c = _map.GetCellAt(fx, fy);
        c.Interact(k);

        Console.BackgroundColor = _facingCursorColor;
        _map.GetCellAt(fx, fy).Display();
        Console.ResetColor();
    }
}