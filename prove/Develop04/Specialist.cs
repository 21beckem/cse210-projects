class Specialist
{
    private List<string> _responses = new()
    {
        "You've got this! Keep pushing forward.",
        "Every step you take is progress. Keep going!",
        "You're capable of amazing things.",
        "Believe in yourself—you're stronger than you think.",
        "Don't stop now. Greatness is just ahead!",
        "One small step today leads to big change tomorrow.",
        "Your potential is limitless. Tap into it!",
        "Stay focused. You're on the right path.",
        "Even the darkest night will end with sunrise.",
        "Success starts with showing up. You're doing great!",
        "Keep your head high and your heart strong.",
        "Challenges are just opportunities in disguise.",
        "Progress, not perfection. You're moving forward!",
        "Every journey begins with a single step—take it!",
        "You're not alone. You've got the strength to rise.",
        "Celebrate your effort—it's what drives success!",
        "Trust the process. You're heading somewhere amazing.",
        "Ride the wave. You're learning and growing every day.",
        "Let go of doubt. You're built for this.",
        "You matter. Your goals matter. Keep going!"
    };
    private List<int> _unusedResponses = new();
    public string GetRandomResponse()
    {
        // if ran out of questions, restart
        if (_unusedResponses.Count < 1)
        {
            for (int i = 0; i < _responses.Count; i++)
            {
                _unusedResponses.Add(i);
            }
        }

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(0, _unusedResponses.Count);
        string output = _responses[ _unusedResponses[magicNumber] ];
        _unusedResponses.RemoveAt(magicNumber);
        return output;
    }
    private void W_(string message="")
    {
        Console.Write(message);
    }
    private void WL(string message = "")
    {
        Console.WriteLine(message);
    }
    private void ConsoleClearLine()
    {
        W_(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
    }
    private void ChadSaySomething(bool intro = false)
    {
        if (!intro) { Thread.Sleep(3000); }
        W_("\nChad is typing...");
        Thread.Sleep(2000);
        Console.SetCursorPosition(0, Console.CursorTop);
        ConsoleClearLine();
        Console.SetCursorPosition(0, Console.CursorTop-1);
        ConsoleClearLine();
        W_("Chad: ");
        if (intro)
        {
            WL("What's up! I'm Chad, I'm here to help");
        }
        else
        {
            WL(GetRandomResponse());
        }
    }
    private void AllowUserInput()
    {
        int startTop = Console.CursorTop;
        WL();
        Console.CursorVisible = true;
        W_("> ");
        string userInput = Console.ReadLine();
        Console.CursorVisible = false;

        // clear every line until we get back to the original startTop
        while (startTop < Console.CursorTop)
        {
            ConsoleClearLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
        W_("You:  ");
        WL(userInput);
    }
    public void Chat()
    {
        Console.CursorVisible = false;
        Console.Clear();
        WL("Chat with a specialist!");
        WL();
        WL("Status: Waiting for a specialist to join the chat...");
        Thread.Sleep(3000);
        WL();
        WL("Status: Chad joined the chat.");
        WL("---------------------------------------------");
        WL();
        Thread.Sleep(1000);

        ChadSaySomething(true);
        for (int i = 0; i < 3; i++)
        {
            AllowUserInput();
            ChadSaySomething();
        }
        Thread.Sleep(750);

        WL("---------------------------------------------");
        WL();
        WL("Status: Chad left the chat.");
        Thread.Sleep(1000);
        Console.CursorVisible = true;
        WL("Status: The chat has been closed. \n");
        W_("Please press enter to go back to the main menu.");
        Console.ReadLine();
    }
}