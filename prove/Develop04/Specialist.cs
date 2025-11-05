class Specialist
{
    private void W_(string message="")
    {
        Console.Write(message);
    }
    private void WL(string message = "")
    {
        Console.WriteLine(message);
    }
    private void ChadSaySomething()
    {
        Thread.Sleep(750);
        W_("Chad is typing...");
        Thread.Sleep(2000);
        Console.SetCursorPosition(0, Console.CursorTop);
        W_("Chad: ");
        WL("Oh yeah!");
    }
    public void Chat()
    {
        Console.Clear();
        WL("Chat with a specialist!");
        WL();
        WL(" Waiting for a specialist to join the chat...");
        Thread.Sleep(3000);
        WL();
        WL("   Chad joined the chat!");
        WL();
        for (int i = 0; i < 3; i++)
        {
            ChadSaySomething();
        }
    }
}