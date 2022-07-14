using System;

public class Parameter
{
    private int _value;

    public Parameter(int defalaulValue)
    {
        _value = defalaulValue;
    }

    public int Value
    {
        get => _value;
        private set
        {
            _value = value;
            Changed?.Invoke(value);
        }
    }

    public event Action<int> Changed;

    public void Set(int value)
    {
        Value = value < 0 ? 0 : value;
    }
}