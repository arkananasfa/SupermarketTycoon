using System;

public class ObservableValue<T>
{

    public Action<T> OnValueChanged;

    public ObservableValue(T value = default)
    {
        Value = value;
    }
    
    public T Value
    {
        get => _value;
        set
        {
            if (_value != null && _value.Equals(value))
                return;
            _value = value;
            OnValueChanged?.Invoke(value);
        }
    }
    
    private T _value;
    
}