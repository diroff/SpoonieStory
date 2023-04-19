using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SimpleAction : MonoBehaviour
{
    [Header("Player parameters")]
    [SerializeField] private Parameter _spoons;
    [SerializeField] private Parameter _hunger;
    [SerializeField] private Parameter _hygiene;
    [Space]
    [SerializeField] private Parameter _variableParameter;
    [Header("Actions cost")]
    [SerializeField] private int _actionSpoonsCost;
    [SerializeField] private int _actionHungerCost;
    [SerializeField] private int _actionHygieneCost;
    [Space]
    [SerializeField] private int _changeValue;
    [Header("Time cost")]
    [SerializeField] private int _hoursActionCost;
    [SerializeField] private int _minutesActionCost;
    [Space]
    [SerializeField] private bool _isRandomTime = false;
    [SerializeField] private int _maxHoursActionCost;
    [SerializeField] private int _maxMinutesActionCost;
    [Space]
    [SerializeField] private TimeManagment _timeManagment;
    [Header("Buttons setting")]
    [SerializeField] private bool _disableInMaximum = true;
    [SerializeField] private bool _disableInMinimum = true;
    [Space]
    [SerializeField] private Actions _actions;
    [SerializeField] private Button _actionButton;

    public virtual void DoAction()
    {
        if (!IsEnoughSpoons() || !IsEqualCondition())
            return;

        _spoons.ReduceValue(_actionSpoonsCost);

        if (_changeValue > 0)
            _variableParameter.AddValue(_changeValue);
        else
            _variableParameter.ReduceValue(-_changeValue);

        _hunger.ReduceValue(_actionHungerCost);
        _hygiene.ReduceValue(_actionHygieneCost);
        SpendTime();
        _actions.CheckActionsState();
    }

    public bool IsEnoughSpoons()
    {
        if (_spoons.CurrentValue < _actionSpoonsCost)
        {
            Debug.Log("Not enough spoons!");
            return false;
        }

        return true;
    }

    public void SetButtonInteractable()
    {
        if (!IsEnoughSpoons() || !IsEqualCondition() || IsMaximum() || IsMinimum())
            _actionButton.interactable = false;
        else
            _actionButton.interactable = true;
    }

    private void SpendTime()
    {
        if (!_isRandomTime)
        {
            _timeManagment.SpendTime(_hoursActionCost, _minutesActionCost);
            return;
        }

        int minutes = 0;
        int hours = 0;

        if (_minutesActionCost != 0)
            minutes = Random.Range(_minutesActionCost, _maxMinutesActionCost + 1);
        if (_hoursActionCost != 0)
            hours = Random.Range(_hoursActionCost, _maxHoursActionCost + 1);

        _timeManagment.SpendTime(hours, minutes);
    }

    public bool IsMaximum()
    {
        if (_disableInMaximum)
            return _variableParameter.IsMaximum();

        return false;
    }
    public bool IsMinimum()
    {
        if (_disableInMinimum)
            return _variableParameter.IsMinimum();

        return false;
    }

    protected virtual bool IsEqualCondition() { return true; }
}