class GoalTracker
{
    private static List<Type> _goalTypes = new();
    public static void AddGoalType(Type g)
    {
        _goalTypes.Add(g);
    }




    private List<Goal> _goals = new();
    private int _totalPts = 0;

    private void Pause()
    {
        Console.Write("\nPress any key to continue...");
        Console.ReadKey();
        Console.WriteLine();
    }

    private void DisplayAlert(string msg)
    {
        Console.Clear();
        Console.WriteLine("\n  " + msg + "\n");
    }

    public void CreateNewGoal()
    {
        Console.WriteLine("The types of goals are:");
        for (int i = 0; i < _goalTypes.Count; i++)
        {
            Type g = _goalTypes[i];
            Console.WriteLine($"  {i+1}. {g}");
        }
        Console.Write("\nEnter the item number of the goal type you'd like to create: ");
        int response = int.Parse( Console.ReadLine() );
        Goal goal = (Goal) Activator.CreateInstance(_goalTypes[response-1]);

        goal.PromptNew();
        _goals.Add(goal);

        DisplayAlert($"Created 1 new {_goalTypes[response-1]}.");
    }
    private void DisplayGoals(bool justName=false)
    {
        if (_goals.Count < 1)
        {
            Console.WriteLine("You have no currently loaded goals.");
        }
        else
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Goal g = _goals[i];
                Console.Write($"  {i+1}. ");
                if (justName)
                {
                    Console.WriteLine(g.GetName());
                }
                else
                {
                    g.Display();
                }
            }
            Console.WriteLine();
        }
    }
    public void ListGoals()
    {
        DisplayGoals(false);
        Pause();
        Console.Clear();
    }
    public void SaveGoals()
    {
        if (_goals.Count < 1)
        {
            DisplayAlert($"You don't have any goals currently loaded. Saving this will overwrite any other goals currently saved.");
            Console.Write("Are you sure? (y/n): ");
            string response = Console.ReadLine();
            if (response != "y" && response != "Y")
            {
                DisplayAlert($"Save canceled.");
                return;
            }
        }
        string filename = "goals.txt";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_totalPts);
            foreach (Goal g in _goals)
            {
                outputFile.WriteLine(g.Stringify());
            }
        }
        
        string s = _goals.Count==1 ? "" : "s";
        DisplayAlert($"Saved {_goals.Count} goal{s}!");
    }
    public void LoadGoals()
    {
        if (_goals.Count > 0)
        {
            DisplayAlert($"You currently have goals loaded. Loading will overwrite what you currently have.");
            Console.Write("Are you sure? (y/n): ");
            string response = Console.ReadLine();
            if (response != "y" && response != "Y")
            {
                DisplayAlert($"Load canceled.");
                return;
            }
        }
        string filename = "goals.txt";

        _goals = new();

        string[] lines = File.ReadAllLines(filename);
        _totalPts = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|@|@|");

            string type = parts[0];
            string[] attrs = parts[1].Split("|$|");
            
            Goal g = (Goal) Activator.CreateInstance(Type.GetType(type));
            g.DeStringify(attrs);
            _goals.Add(g);
        }

        string s = lines.Length==2 ? "" : "s";
        DisplayAlert($"Loaded {lines.Length-1} goal{s}!");
    }
    public void RecordEvent()
    {
        DisplayGoals(true);
        if (_goals.Count < 1)
        {
            Pause();
            Console.Clear();
        }
        else
        {
            Console.Write("Enter which goal you acomplished: ");
            int response = int.Parse(Console.ReadLine());
            Goal g = _goals[response-1];
            int earned = g.RecordEvent();
            _totalPts += earned;
            
            string congrats = earned > 0 ? "Congradulations!" : "Well, sorry.";
            DisplayAlert($"{congrats} You have earned {earned} points.");
        }
    }
    public void Quit()
    {
        Environment.Exit(0);
    }
    public void DisplayMenu()
    {
        Console.Clear();
        while (true)
        {
            Console.Write(string.Join("\n", new List<string> {
               $"You currently have {_totalPts} points",
                "",
                "Menu Options",
                "  1. Create New Goal",
                "  2. List Goals",
                "  3. Save Goals",
                "  4. Load Goals",
                "  5. Record Event",
                "  6. Quit",
                "",
                "Select a choice from the menu: "
            }));
            int response = int.Parse(Console.ReadLine());
            string methodName = new List<string>
            {
                "CreateNewGoal",
                "ListGoals",
                "SaveGoals",
                "LoadGoals",
                "RecordEvent",
                "Quit"
            }[response-1];
            
            Console.Clear();
            GetType().GetMethod(methodName).Invoke(this, null);
        }
    }
}