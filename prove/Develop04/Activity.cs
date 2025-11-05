class Activity
{
    private int _duration;
    protected string _activityName;
    protected string _description;
    private DateTime _startTimestamp;

    private List<string> _prompts;
    private List<string> _questions;
    private List<int> _unusedQuestions = new();

    public Activity(string name, string desc, List<string> prompts=null, List<string> questions=null)
    {
        _activityName = name;
        _description = desc;
        _prompts = prompts;
        _questions = questions;
    }

    public string GetRandomPrompt()
    {
        if (_prompts == null || _prompts.Count < 1) { return ""; }
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(0, _prompts.Count);
        return _prompts[magicNumber];
    }
    public string GetRandomQuestion()
    {
        if (_questions == null || _questions.Count < 1) { return ""; }
        // if ran out of questions, restart
        if (_unusedQuestions.Count < 1)
        {
            for (int i = 0; i < _questions.Count; i++)
            {
                _unusedQuestions.Add(i);
            }
        }

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(0, _unusedQuestions.Count);
        string output = _questions[ _unusedQuestions[magicNumber] ];
        _unusedQuestions.RemoveAt(magicNumber);
        return output;
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