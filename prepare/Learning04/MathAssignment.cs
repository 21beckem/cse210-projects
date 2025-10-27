class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;


    public MathAssignment(string name, string topic, string textSec, string probs): base(name, topic)
    {
        _textbookSection = textSec;
        _problems = probs;
    }


    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}