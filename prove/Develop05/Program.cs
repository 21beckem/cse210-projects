class Program
{
    static void Main(string[] args)
    {
        // GoalTracker.AddGoalType(typeof(Goal));
        GoalTracker.AddGoalType(typeof(SimpleGoal));
        GoalTracker.AddGoalType(typeof(EternalGoal));
        GoalTracker.AddGoalType(typeof(ChecklistGoal));
        
        GoalTracker gt = new();
        gt.DisplayMenu();
    }
}