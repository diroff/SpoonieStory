using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SimpleAction : MonoBehaviour
{
    [Header("Player parameters")]
    [SerializeField] protected Parameter _spoons;
    [SerializeField] protected Parameter _hunger;
    [SerializeField] protected Parameter _hygiene;
    [Space]
    [SerializeField] protected Parameter _variableParameter;
    [Header("Actions cost")]
    [SerializeField] protected int _actionSpoonsCost;
    [SerializeField] protected int _actionHungerCost;
    [SerializeField] protected int _actionHygieneCost;
    [Space]
    [SerializeField] protected int _changeValue;
    [Header("Time cost")]
    [SerializeField] private int _hoursActionCost;
    [SerializeField] protected int _minutesActionCost;
    [Space]
    [SerializeField] private bool _isRandomTime = false;
    [SerializeField] private int _maxHoursActionCost;
    [SerializeField] private int _maxMinutesActionCost;
    [Space]
    [SerializeField] protected TimeManagment _timeManagment;
    [Header("Buttons setting")]
    [SerializeField] private bool _disableInMaximum = true;
    [SerializeField] private bool _disableInMinimum = true;
    [Space]
    [SerializeField] protected Actions _actions;
    [SerializeField] private Button _actionButton;
    [Header("Time limited")]
    [SerializeField] private bool _limitedTime = false;
    [SerializeField] private int _minHoursActivation;
    [SerializeField] private int _maxHoursActivation;
    [SerializeField] private bool _limitedMinutes = false;
    [SerializeField] private int _minMinutesActivation;
    [SerializeField] private int _maxMinutesActivation;
    [Space]
    [SerializeField] private bool _canBeHided = false;

    protected int _hoursBeforeAction;
    protected int _hoursSpent;

    public virtual void DoAction()
    {
        if (!IsEnoughSpoons() || !IsEqualCondition())
            return;

        if (_timeManagment.Emotions.Sad.IsActive)
            _hunger.ReduceValue(4);

        if (_timeManagment.Emotions.Excited.IsActive)
        {
            if(_actionSpoonsCost == 3)
                _actionSpoonsCost = 2;
        }

        _spoons.ReduceValue(_actionSpoonsCost);

        if(_variableParameter == _hunger && _timeManagment.Emotions.Excited.IsActive)
        {
            if (_changeValue > 0)
                _hunger.AddValue(_changeValue);
        }
        else
        {
            if (_changeValue > 0)
                _variableParameter.AddValue(_changeValue);
            else
                _variableParameter.ReduceValue(-_changeValue); // Reduce(-value)?
        }

        if (_timeManagment.Emotions.Excited.IsActive)
        {
            if(_actionHungerCost < 0)
                _hunger.ReduceValue(_actionHungerCost);
        }
        else
            _hunger.ReduceValue(_actionHungerCost);

        _hygiene.ReduceValue(_actionHygieneCost);
        SpendTime();

        AlertController.Alerts.CheckParamsAlerts();
        _actions.CheckActionsState();
    }

    public bool IsEnoughSpoons()
    {
        if (_spoons.CurrentValue < _actionSpoonsCost)
            return false;

        return true;
    }

    public void SetButtonInteractable()
    {
        if (!IsEnoughSpoons() || !IsEqualCondition() || IsMaximum() || IsMinimum() || !IsAvailableTime())
        {
            if (_canBeHided)
                _actionButton.gameObject.SetActive(false);
            else
                _actionButton.interactable = false;
        }
        else
        {
            if (_canBeHided)
                _actionButton.gameObject.SetActive(true);
            else
                _actionButton.interactable = true;
        }
    }

    protected void SpendTime()
    {
        if (!_isRandomTime)
        {
            _timeManagment.SpendTime(_hoursActionCost, _minutesActionCost);
            return;
        }

        int minutes = 0;
        int hours = 0;

        _hoursBeforeAction = _timeManagment.CurrentHours;

        if (_minutesActionCost != 0)
            minutes = Random.Range(_minutesActionCost, _maxMinutesActionCost + 1);
        if (_hoursActionCost != 0)
            hours = Random.Range(_hoursActionCost, _maxHoursActionCost + 1);

        _timeManagment.SpendTime(hours, minutes);

        _hoursSpent = hours;
    }

    private bool IsAvailableTime()
    {
        if (!_limitedTime)
            return true;

        if (_timeManagment.CurrentHours >= _minHoursActivation  && _timeManagment.CurrentHours <= _maxHoursActivation)
        {
            if (!_limitedMinutes)
            {
                if(_timeManagment.CurrentHours >= _minHoursActivation && _timeManagment.CurrentHours < _maxHoursActivation)
                    return true;
            }
                
            else
            {
                if(_minHoursActivation == _timeManagment.CurrentHours)
                {
                    if (_minMinutesActivation < _timeManagment.CurrentMinutes)
                        return true;
                    else
                        return false;
                }

                if(_maxHoursActivation == _timeManagment.CurrentHours)
                {
                    if (_maxMinutesActivation > _timeManagment.CurrentMinutes)
                        return true;
                    else
                        return false;
                }

                return true;
            }
        }

        if(_minHoursActivation >= 20 && _maxHoursActivation < 8)
        {
            if (_timeManagment.CurrentHours >= _minHoursActivation || _timeManagment.CurrentHours < _maxHoursActivation)
                return true;
        }

        return false;
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