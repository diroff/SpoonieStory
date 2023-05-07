using UnityEngine;
using UnityEngine.Events;

public class Grade : Parameter
{
    [SerializeField] private string _reason;
    [SerializeField] private EmotionController _emotions;

    public UnityEvent<string> GradesOver;
    public string Reason => _reason;

    public override void ReduceValue(int count)
    {
        if(count > 0 || count < 0)
        {
            if (_emotions.Bored.IsActive)
                count--;

            else if (_emotions.Attentive.IsActive)
                count++;
        }

        base.ReduceValue(count);

        if(_currentValue <= _minValue)
            GradesOver?.Invoke(_reason);
    }

    public override void AddValue(int count)
    {
        if (count > 0 || count < 0)
        {
            if (_emotions.Bored.IsActive)
                count--;

            else if (_emotions.Attentive.IsActive)
                count++;

        }

        base.AddValue(count);
    }
}