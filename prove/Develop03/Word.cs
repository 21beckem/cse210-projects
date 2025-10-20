class Word
{
    private bool _isHidden;
    private string _value;
    private string _puncuation;

    public Word(string value)
    {
        if (Char.IsPunctuation(value[value.Length - 1]))
        {
            _puncuation = value[value.Length - 1].ToString();
            _value = value.Remove(value.Length - 1);
        }
        else
        {
            _puncuation = "";
            _value = value;
        }
        _isHidden = false;
    }
    public bool GetIsHidden() { return _isHidden; }
    public void SetIsHidden(bool v) { _isHidden = v; }
    public void Display()
    {
        if (_isHidden)
        {
            Console.Write(" " + new string('_', _value.Length) + _puncuation);
        }
        else
        {
            Console.Write(" " + _value + _puncuation);
        }
    }
}