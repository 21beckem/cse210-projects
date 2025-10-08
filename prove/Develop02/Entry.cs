class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public Entry(string prompt, string response, string date = null)
    {
        if (date == null) { date = DateTime.Now.ToShortDateString(); }
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
    }

    public static Entry Parse(string str)
    {
        string[] parts = str.Split("~|~");
        return new Entry(parts[0], parts[1], parts[2]);
    }
    public string Stringify()
    {
        return $"{_prompt}~|~{_response}~|~{_date}";
    }
}