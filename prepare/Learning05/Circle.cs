class Circle : Shape
{
    private double _radius;

    public Circle(string color, double side) : base(color)
    {
        _radius = side;
        _name = "Circle";
    }

    public override double GetArea()
    {
        return Math.PI * _radius *_radius;
    }
}