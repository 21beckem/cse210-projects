class Program
{
    static void Main(string[] args)
    {
        // Declare Defaults
        Reference myRef = new("Matthew", 5, 14, 16);
        Scripture myScrip = new(
            myRef,
            "Ye are the light of the world. A city that is set on an hill cannot be hid. Neither do men light a candle, and put it under a bushel, but on a candlestick; and it giveth light unto all that are in the house. Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven."
        );
        int numToHide = 3;


        // startup menu
        while (true)
        {
            Console.Clear();
            Console.Write(String.Join("\n", [
                "",
                "             Welcome to",
                "        Scripture Memorizer",
                "",
                "     Current Scripture: " + myRef.ToString(),
                "",
                "  Select a choice from the menu:",
                "",
                "  (s) Start!",
                "  (d) Declare custom scripture",
                "  (n) Number of words to hide at a time",
                "  (q) Quit",
                "",
                "------------------------------------",
                "",
                "Enter your choice: "
            ]));
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (choice == 's')
            {
                break;
            }
            else if (choice == 'd')
            {
                Console.WriteLine("\nWhat is the name of the book of your scripture?");
                Console.Write("> ");
                string book = Console.ReadLine();
                Console.WriteLine("\nWhat is the scripture chapter number?");
                Console.Write("> ");
                int chap = int.Parse(Console.ReadLine());
                
                Console.WriteLine("\nDoes your scripture contain multiple verses? (hit y or n)");
                Console.Write("> ");
                int v1 = 0, v2 = 0;
                if (Console.ReadKey().KeyChar == 'y')
                {
                    Console.WriteLine("\nWhat is the first verse number?");
                    Console.Write("> ");
                    v1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nWhat is the second verse number?");
                    Console.Write("> ");
                    v2 = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("\nWhat is the verse number?");
                    Console.Write("> ");
                    v1 = int.Parse(Console.ReadLine());
                }
                myRef = new(book, chap, v1, v2);

                Console.WriteLine("\nPlease paste all the text here:");
                Console.Write("> ");
                string wholeText = Console.ReadLine();

                myScrip = new(myRef, wholeText);
            }
            else if (choice == 'n')
            {
                Console.WriteLine("How many words should be taken away at a time? Currently: " + numToHide);
                Console.Write("> ");
                numToHide = int.Parse(Console.ReadLine());
            }
            else if (choice == 'q')
            {
                return;
            }
        }


        // memorizer part
        while (true)
        {
            myScrip.Display();
            Console.WriteLine("\nPress Enter to hide words. Type q + Enter to quit.");
            string input = Console.ReadLine();
            if (input == "q") { break; }
            if (!myScrip.Hide(numToHide)) { break; }
        }
        
        Console.WriteLine("\nYou did it!");
    }
}