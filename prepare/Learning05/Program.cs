class Program
{
    static void Main(string[] args)
    {
        Square s = new("green", 2);
        Console.WriteLine("square: " + s.GetArea());
        
        Rectangle r = new("green", 5, 2);
        Console.WriteLine("rectangle: " + r.GetArea());
        
        Circle c = new("green", 1);
        Console.WriteLine("circle: " + c.GetArea());


        Console.WriteLine("-----------------------------------");


        List<Shape> shapes = new()
        {
            new Square("green", 2),
            new Rectangle("red", 5, 2),
            new Circle("blue", 1)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine("Name: " + shape.GetName());
            Console.WriteLine("Color: " + shape.GetColor());
            Console.WriteLine("Area: " + shape.GetArea());
            Console.WriteLine();
        }
    }
}