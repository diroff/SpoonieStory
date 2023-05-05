using TMPro;
using UnityEngine;

public class TimeOfDayDisplayer : MonoBehaviour
{
    [SerializeField] private TimeManagment _timeManagment;
    [SerializeField] private TextMeshProUGUI _timeText;

    private void OnEnable()
    {
        _timeManagment.HoursChanged += ShowTimeOfDay;
    }

    private void OnDisable()
    {
        _timeManagment.HoursChanged -= ShowTimeOfDay;
    }

    private void ShowTimeOfDay(int currentTime)
    {
        if(currentTime >= 6 && currentTime < 11)
            _timeText.text = "(morning)";
        else if (currentTime >= 11 && currentTime < 17)
            _timeText.text = "(day)";
        else if (currentTime >= 17 && currentTime < 21)
            _timeText.text = "(evening)";
        else
            _timeText.text = "(night)";
    }
}