using TMPro;
using UnityEngine;

public class MinutesDisplayer : MonoBehaviour
{
    [SerializeField] private TimeManagment _timeManagment;
    [SerializeField] private TextMeshProUGUI _timeValue;

    private void OnEnable()
    {
        _timeManagment.MinutesChanged += DisplayTime;
    }

    private void OnDisable()
    {
        _timeManagment.MinutesChanged -= DisplayTime;
    }

    private void DisplayTime(int minutes)
    {
        _timeValue.text = "";

        if (_timeManagment.CurrentMinutes < 10)
            _timeValue.text += "0";

        _timeValue.text += minutes.ToString();
    }
}