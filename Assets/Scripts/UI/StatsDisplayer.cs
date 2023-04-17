using TMPro;
using UnityEngine;

public class StatsDisplayer : MonoBehaviour
{
    [SerializeField] private Parameter _parameter;
    [SerializeField] private TextMeshProUGUI _parameterText;

    private void OnEnable()
    {
        _parameter.ValueChanged += DisplayParameterValue;
    }

    private void OnDisable()
    {
        _parameter.ValueChanged -= DisplayParameterValue;
    }

    private void DisplayParameterValue(int currentValue, int maxValue)
    {
        _parameterText.text = _parameter.CurrentValue + "/" + _parameter.MaxValue;
    }
}