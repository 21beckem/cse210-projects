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
        Console.WriteLine("\n  " + msg);
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

        Console.Clear();
        Console.WriteLine($"\n  Created 1 new {_goalTypes[response-1]}.\n");
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
    public void Save()
    {

    }
    public void Load()
    {

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
            
            Console.Clear();
            DisplayAlert($"Congradulations! You have earned {earned} points!");
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
                "",
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