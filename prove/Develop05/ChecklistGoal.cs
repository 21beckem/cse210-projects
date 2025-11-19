class ChecklistGoal : Goal
{
    private int _timesNeeded;
    private int _bonusPoints;
    private int _timesDone;

    public override void PromptNew()
    {
        base.PromptNew();
        Console.Write("Enter the amount of times this goal needs to be accomplished for a bonus: ");
        _timesNeeded = int.Parse(Console.ReadLine());
        Console.Write("Enter the bonus amount for accomplishing it that many times (must be a whole number): ");
        _bonusPoints = int.Parse(Console.ReadLine());
        _timesDone = 0;
    }

    public override void Display(bool endWithNewLine=true)
    {
        base.Display(false);
        Console.WriteLine($" -- Currently completed: {_timesDone}/{_timesNeeded}");
    }

    
    public override string Stringify()
    {
        return $"{base.Stringify()}|$|{_timesNeeded}|$|{_bonusPoints}|$|{_timesDone}";
    }
    public override void DeStringify(string[] attrs)
    {
        base.DeStringify(attrs);
        _timesNeeded = int.Parse(attrs[4]);
        _bonusPoints = int.Parse(attrs[5]);
        _timesDone = int.Parse(attrs[6]);
    }

    public override int RecordEvent()
    {
        int points = base.RecordEvent();
        _timesDone += 1;
        if (_timesDone == _timesNeeded)
        {
            points += _bonusPoints;
            _done = true;
        }

        return points;
    }
}