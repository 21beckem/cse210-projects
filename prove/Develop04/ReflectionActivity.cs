class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private List<int> _unusedQuestions = new();


    public ReflectionActivity() : base(
        "Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    )
    { }


    private string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(0, _prompts.Count);
        return _prompts[magicNumber];
    }
    private string GetRandomQuestion()
    {
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

    public override void RunActivity()
    {
        // intro
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        // get ready again...
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in ");
        Loader(5);

        // reflect
        StartTimer();
        Console.Clear();
        while (true)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            Loader(15);
            if (IsTimerDone())
            {
                break;
            }
        }
    }
        
}