using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManagment : MonoBehaviour
{
    [SerializeField] private int _startDays;
    [SerializeField] private int _startHours;
    [SerializeField] private int _startMinutes;

    [SerializeField] private Grade _grade;
    [SerializeField] private StudyController _studyController;

    private int _currentDays;
    private int _currentHours;
    private int _currentMinutes;
    private int _currentWeekDayNumber;

    private int _previousHour;

    private List<string> _weekDays = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    private string _currentWeekDay;
    private bool _schoolStarted = true;

    public int CurrentDays => _currentDays;
    public int CurrentHours => _currentHours;
    public int CurrentMinutes => _currentMinutes;

    public string CurrentWeekDay => _currentWeekDay;

    public UnityAction<int, string> DayChanged;
    public UnityAction<int> HoursChanged;
    public UnityAction<int> MinutesChanged;
    public UnityEvent SchoolEnded;

    private void Start()
    {
        _currentDays = _startDays;
        _currentHours = _startHours;
        _currentMinutes = _startMinutes;
        _previousHour = _currentHours;
        _currentWeekDayNumber = 0;

        HoursChanged?.Invoke(_currentHours);
        MinutesChanged?.Invoke(_currentMinutes);
        DayChanged?.Invoke(_currentDays, _weekDays[_currentWeekDayNumber]);
    }

    public void SpendTime(int hours, int minutes)
    {
        _previousHour = _currentHours;

        _currentHours += hours;
        _currentMinutes += minutes;

        if (_currentMinutes >= 60)
        {
            _currentHours++;
            _currentMinutes -= 60;
        }

        if (IsDayChanged())
        {
            _currentHours = _currentHours - 24;
            SetNextDay();
        }

        HoursChanged?.Invoke(_currentHours);
        MinutesChanged?.Invoke(_currentMinutes);
        SchoolEndChecker();
    }

    public void SetTime(int hours, int minutes)
    {
        _currentHours = hours;
        _currentMinutes = minutes;

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
        _grade.ReduceValue(2);
        _schoolStarted = true;
        _studyController.WasInSchool(false);
    }

    private void SchoolEndChecker()
    {
        if(_schoolStarted && _currentHours >= 14)
        {
            if(_currentHours == 14)
            {
                if (_currentMinutes < 40)
                    return;
            }

            _schoolStarted = false;
            Debug.Log("School ended");
            SchoolEnded?.Invoke();
        }
    }

    private bool IsDayChanged() { return _currentHours >= 24 && _previousHour < 24; }
}