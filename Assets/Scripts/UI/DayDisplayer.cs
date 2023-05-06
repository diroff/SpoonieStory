using TMPro;
using UnityEngine;

public class DayDisplayer : MonoBehaviour
{
    [SerializeField] private TimeManagment _timeManagment;
    [SerializeField] private TextMeshProUGUI _timeValue;

    private void OnEnable()
    {
        _timeManagment.DayChanged += DisplayDay;
    }

    private void OnDisable()
    {
        _timeManagment.DayChanged -= DisplayDay;
    }

    private void DisplayDay(int day, string dayWeek)
    {
        _timeValue.text = "Day " + day + ": " + dayWeek;
    }
}