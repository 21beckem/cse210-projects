class Goal
{
    protected string _name;
    protected string _desc;
    protected bool _done;
    protected int _pts;

    public string GetName() { return _name; }
    public virtual void PromptNew()
    {
        Console.Write("Enter the name of your goal: ");
        _name = Console.ReadLine();
        Console.Write("Enter a short description of it: ");
        _desc = Console.ReadLine();
        Console.Write("Enter the number of points associated with this goal (must be a whole number): ");
        _pts = int.Parse(Console.ReadLine());
    }
    public void Display()
    {
        string check = _done ? "[X]" : "[ ]";
        Console.WriteLine($"{check} {_name} ({_desc})");
    }
    public virtual string Stringify()
    {
        return $"{GetType()}|@|@|{_name}|$|{_desc}|$|{_pts}";
    }
    public virtual int RecordEvent()
    {
        return _pts;
    }
}