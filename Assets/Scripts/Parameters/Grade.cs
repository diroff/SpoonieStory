using UnityEngine.Events;

public class Grade : Parameter
{
    public UnityEvent GradesOver;

    public override void ReduceValue(int count)
    {
        base.ReduceValue(count);

        if(_currentValue <= _minValue)
            GradesOver?.Invoke();
    }
}