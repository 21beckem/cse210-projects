class Shape
{
    private string _color;
    protected string _name;


    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }
    public string GetName()
    {
        return _name;
    }
    public void SetColor(string val)
    {
        _color = val;
    }

    public virtual double GetArea()
    {
        return 0.0;
    }
}