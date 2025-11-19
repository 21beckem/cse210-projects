class SimpleGoal : Goal
{
    public override int RecordEvent()
    {
        if (!_done)
        {
            _done = true;
            return base.RecordEvent();
        }
        return 0;
    }
}