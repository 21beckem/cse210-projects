class ListingActivity : Activity
{
    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
        new() {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        }
    )
    { }

    public override void RunActivity()
    {
        // intro
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine();
        Console.WriteLine("You may begin in ");
        Loader(10);

        // reflect
        StartTimer();
        while (true)
        {
            Console.Write($"> ");
            Console.ReadLine();
            if (IsTimerDone())
            {
                break;
            }
        }
    }
}