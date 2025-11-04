class Activity
{
    private int _duration;
    protected string _activityName;
    protected string _description;
    private DateTime _startTimestamp;

    public Activity(string name, string desc)
    {
        _activityName = name;
        _description = desc;
    }

    private bool DisplayStartMsg()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        string res = Console.ReadLine();
        if (!int.TryParse(res, out _duration))
        {
            Console.WriteLine("Oh no. Looks like that wasn't an integer. Returning to main menu...");
            Loader(3);
            return false;
        }
        return true;
    }
    private void DisplayGetReadyMsg()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        Loader(3);
    }
    private void DisplayEndMsg()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Loader(3);
        Console.WriteLine($"You've completed another {_duration} seconds of the {_activityName} Activity");
        Loader(5);
    }
    public void Loader(int duration, bool endWithNewLine=true)
    {
        Console.CursorVisible = false;

        int startLeft = Console.CursorLeft;
        char[] loaderChars = new[] { '/', '-', '\\', '|' };
        for (int i = 0; i < duration; i++)
        {
            Console.SetCursorPosition(startLeft, Console.CursorTop);
            Console.Write(duration - i);
            Console.Write("  ");
            for (int j = 0; j < loaderChars.Length; j++)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(loaderChars[j]);
                Thread.Sleep(1000 / loaderChars.Length);
            }
        }
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        Console.Write(" ");
        Console.SetCursorPosition(startLeft, Console.CursorTop);
        Console.Write("    ");

        if (endWithNewLine)
        {
            Console.WriteLine();
        }
        
        Console.CursorVisible = true;
    }
    public virtual void RunActivity()
    {
        Console.WriteLine("Nothin' to see here. Try overwriting this function ;)");
    }
    public void Start()
    {
        if (!DisplayStartMsg()) { return; }
        DisplayGetReadyMsg();
        RunActivity();
        DisplayEndMsg();
    }
    public void StartTimer()
    {
        _startTimestamp = DateTime.UtcNow;
    }
    public bool IsTimerDone()
    {
        DateTime now = DateTime.UtcNow;
        TimeSpan timeElapsed = now - _startTimestamp;
        return timeElapsed > TimeSpan.FromSeconds(_duration);
    }
}