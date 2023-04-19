using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Parameter : MonoBehaviour
{
    [SerializeField] private int _startValue;
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    private int _currentValue;

    public int StartValue => _startValue;
    public int CurrentValue => _currentValue;
    public int MinValue => _minValue;
    public int MaxValue => _maxValue;

    public UnityAction<int, int> ValueChanged;

    private void Awake()
    {
        _currentValue = _startValue;
        FixValues();
    }

    private void Start()
    {
        ValueChanged?.Invoke(_currentValue, _maxValue);
    }

    public void AddValue(int count)
    {
        if (IsMaximum())
            return;

        _currentValue += count;
        FixValues();
        ValueChanged?.Invoke(_currentValue, _maxValue);
    }

    public void ReduceValue(int count)
    {
        if (IsMinimum())
            return;

        _currentValue -= count;
        FixValues();
        ValueChanged?.Invoke(_currentValue, _maxValue);
    }
    
    private void FixValues()
    {
        if (IsMaximum()) _currentValue = _maxValue;
        if (IsMinimum()) _currentValue = _minValue;
    }

    public bool IsMaximum() { return _currentValue >= _maxValue; }
    public bool IsMinimum() { return _currentValue <= _minValue; }
}