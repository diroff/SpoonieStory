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
    [SerializeField] private int _minutesActionCost;
    [SerializeField] private int _hoursActionCost;
    [Space]
    [SerializeField] private TimeManagment _timeManagment;
    [Header("Buttons setting")]
    [SerializeField] private bool _disableInMaximum = true;
    [SerializeField] private bool _disableInMinimum = true;

    private Actions _actions;
    private Button _actionButton;

    private void Awake()
    {
        _actionButton = GetComponent<Button>();
        _actions = GetComponentInParent<Actions>();
    }

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
        _timeManagment.SpendTime(_hoursActionCost, _minutesActionCost);
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

    public bool IsMaximum() 
    { 
        if(_disableInMaximum)
            return _variableParameter.IsMaximum();

        return false;
    }
    public bool IsMinimum() 
    { 
        if(_disableInMinimum)
            return _variableParameter.IsMinimum();

        return false;
    }

    protected virtual bool IsEqualCondition() { return true; }
}