using TMPro;
using UnityEngine;

public class StatsDisplayer : MonoBehaviour
{
    [SerializeField] private Parameter _parameter;
    [SerializeField] protected TextMeshProUGUI _parameterText;

    private void OnEnable()
    {
        _parameter.ValueChanged += DisplayParameterValue;
        DisplayParameterValue(_parameter.CurrentValue, _parameter.MaxValue);
    }

    private void OnDisable()
    {
        _parameter.ValueChanged -= DisplayParameterValue;
    }

    protected virtual void DisplayParameterValue(int currentValue, int maxValue)
    {
        _parameterText.text = "";
        _parameterText.text = _parameter.CurrentValue + "/" + _parameter.MaxValue;
    }
}