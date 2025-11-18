class SimpleGoal : Goal
{
    public override int RecordEvent()
    {
        _done = true;
        return base.RecordEvent();
    }
}