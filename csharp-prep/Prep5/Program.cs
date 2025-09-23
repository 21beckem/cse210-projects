using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserFavNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    static int PromptUserBirthYear()
    {
        Console.Write("Please enter the year you were born: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int num)
    {
        return num * num;
    }
    static void DisplayResult(string name, int squaredNum, int birthYear)
    {
        int ageThisYear = DateTime.Now.Year - birthYear;
        Console.WriteLine($"{name}, the square of your number is {squaredNum}");
        Console.WriteLine($"{name}, you will turn/have already turned {ageThisYear} this year.");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favNum = PromptUserFavNumber();
        int birthYear = PromptUserBirthYear();

        DisplayResult(name, SquareNumber(favNum), birthYear);
    }
}