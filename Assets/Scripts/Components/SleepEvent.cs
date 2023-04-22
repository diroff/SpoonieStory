using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepEvent : MonoBehaviour
{
    [SerializeField] private Parameter _spoons;

    [SerializeField] private int _maxBonus;

    public void CalculateSpoonsCount()
    {
        _spoons.SetValue(Random.Range(12, 19));
        _spoons.AddValue(Random.Range(0, _maxBonus + 1));
    }
}