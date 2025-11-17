using System;

class Program
{
    static void Main(string[] args)
    {
        // GoalTracker.AddGoalType(typeof(Goal));
        GoalTracker.AddGoalType(typeof(SimpleGoal));
        
        GoalTracker gt = new();
        gt.DisplayMenu();
    }
}