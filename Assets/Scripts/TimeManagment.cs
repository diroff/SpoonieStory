using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManagment : MonoBehaviour
{
    [SerializeField] private int _startDays; 
    [SerializeField] private int _startHours; 
    [SerializeField] private int _startMinutes; 

    private int _currentDays;
    private int _currentHours;
    private int _currentMinutes;
    private int _currentWeekDayNumber;

    private List<string> _weekDays = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    private string _currentWeekDay;

    public int CurrentDays => _currentDays;
    public int CurrentHours => _currentHours;
    public int CurrentMinutes => _currentMinutes;

    public string CurrentWeekDay;

    public UnityAction<int, string> DayChanged;
    public UnityAction<int> HoursChanged;
    public UnityAction<int> MinutesChanged;

    private void Start()
    {
        _currentDays = _startDays;
        _currentHours = _startHours;
        _currentMinutes = _startMinutes;
        _currentWeekDayNumber = 0;

        HoursChanged?.Invoke(_currentHours);
        MinutesChanged?.Invoke(_currentMinutes);
        DayChanged?.Invoke(_currentDays, _weekDays[_currentWeekDayNumber]);
    }

    public void SpendTime(int hours, int minutes)
    {
        _currentHours += hours;
        _currentMinutes += minutes;

        if (_currentMinutes >= 60)
        {
            _currentHours++;
            _currentMinutes -= 60;
        }

        if (IsDayChanged())
        {
            _currentHours = 0;
            SetNextDay();
        }

        HoursChanged?.Invoke(_currentHours);
        MinutesChanged?.Invoke(_currentMinutes);
    }

    public void SetNextDay()
    {
        _currentDays++;
        _currentWeekDayNumber++;

        if (_currentWeekDayNumber >= _weekDays.Count)
            _currentWeekDayNumber = 0;

        _currentWeekDay = _weekDays[_currentWeekDayNumber];
        DayChanged?.Invoke(_currentDays, _weekDays[_currentWeekDayNumber]);
    }

    private bool IsDayChanged() { return _currentHours == 24; }
}