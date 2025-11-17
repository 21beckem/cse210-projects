class SimpleGoal : Goal
{
    public override void PromptNew()
    {
        base.PromptNew();
        Console.WriteLine("creating new simple goal");
    }
    public override string Stringify()
    {
        base.Stringify();
        throw new NotImplementedException();
    }
    public override int RecordEvent()
    {
        base.RecordEvent();
        throw new NotImplementedException();
    }
}