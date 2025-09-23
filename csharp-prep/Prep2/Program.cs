using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        int perc = int.Parse(Console.ReadLine());
        int lastDig = perc % 10;

        string sign = "";
        if (lastDig >= 7)
        {
            sign = "+";
        }
        else if (lastDig < 3)
        {
            sign = "-";
        }

        string letterGrade;
        if (perc >= 90)
        {
            if (perc >= 97)
            {
                sign = "";
            }
            letterGrade = "A";
        }
        else if (perc >= 80)
        {
            letterGrade = "B";
        }
        else if (perc >= 70)
        {
            letterGrade = "C";
        }
        else if (perc >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
            sign = "";
        }

        Console.WriteLine($"Your letter-grade is: {letterGrade}{sign}");
    }
}