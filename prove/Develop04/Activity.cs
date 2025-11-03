class Activity
{
    private int _duration;
    protected string _activityName;
    protected string _description;
    private DateTime _startTimestamp;


    private bool DisplayStartMsg()
    {
        Console.WriteLine($"Welcome to the {_activityName} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        string res = Console.ReadLine();
        return int.TryParse(res, out _duration);
    }
    private void DisplayEndMsg()
    {
        Console.WriteLine();
    }
    public void Loader(int duration)
    {
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
        Console.Write("0");
    }
    public virtual void RunActivity()
    {
        Console.WriteLine("Nothin' to see here. Try overwriting this function ;)");
    }
    public void Start()
    {
        if (!DisplayStartMsg()) { return; }
        Loader(3);
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