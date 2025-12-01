class Character {
    private int _posX;
    private int _posY;
    private char _facing; // 'N', 'E', 'S', 'W'

    public Character(int posX, int posY)
    {
        _posX = posX;
        _posY = posY;
        _facing = 'E';
    }

    
    public void Display()
    {
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
    public bool AreYouHere(int posX, int posY)
    {
        return (posX==_posX && posY==_posY);
    }
}