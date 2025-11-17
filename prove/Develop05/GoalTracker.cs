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
    public void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal g = _goals[i];
            Console.Write($"  {i+1}. ");
            g.Display();
        }
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
            Console.Write(String.Join("\n", new List<string> {
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