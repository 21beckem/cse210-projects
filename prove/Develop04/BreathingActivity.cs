class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
    ) { }

    public override void RunActivity()
    {
        StartTimer();
        while (true)
        {
            Console.Write("Breathe in... ");
            Loader(4);
            Console.Write("Breathe out... ");
            Loader(4);
            if (IsTimerDone())
            {
                break;
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
        
}