class Word
{
    private bool _isHidden;
    private string _value;

    public Word(string value)
    {
        _value = value;
        _isHidden = false;
    }
    public bool GetIsHidden()
    {
        return _isHidden;
    }
    public void SetIsHidden(bool v)
    {
        _isHidden = v;
    }
    public void Display()
    {
        if (_isHidden)
        {
            Console.Write(" " + new string('_', _value.Length));
        }
        else
        {
            Console.Write(" " + _value);
        }
    }
}