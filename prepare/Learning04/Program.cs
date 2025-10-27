using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new("Michael", "Programming");
        Console.WriteLine(assignment1.GetSummary());

        Console.WriteLine();

        MathAssignment math = new("Matthew", "Fractions", "7.2", "8-19");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment write = new("Joe", "Creative Writing", "Personal Narrative");
        Console.WriteLine(write.GetSummary());
        Console.WriteLine(write.GetWritingInformation());
    }
}