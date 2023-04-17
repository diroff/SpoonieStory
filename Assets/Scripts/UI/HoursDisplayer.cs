using TMPro;
using UnityEngine;

public class HoursDisplayer : MonoBehaviour
{
    [SerializeField] private TimeManagment _timeManagment;
    [SerializeField] private TextMeshProUGUI _timeValue;

    private void OnEnable()
    {
        _timeManagment.HoursChanged += DisplayTime;
    }

    private void OnDisable()
    {
        _timeManagment.HoursChanged -= DisplayTime;
    }

    private void DisplayTime(int hours)
    {
        _timeValue.text = "";

        if (_timeManagment.CurrentHours < 10)
            _timeValue.text += "0";

        _timeValue.text += hours.ToString();
    }
}