using UnityEngine;
using UnityEngine.Events;

public class Grade : Parameter
{
    [SerializeField] private string _reason;

    public UnityEvent<string> GradesOver;
    public string Reason => _reason;

    public override void ReduceValue(int count)
    {
        base.ReduceValue(count);

        if(_currentValue <= _minValue)
            GradesOver?.Invoke(_reason);
    }
}