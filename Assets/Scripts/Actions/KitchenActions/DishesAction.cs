using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DishesAction : SimpleAction
{
    [SerializeField] protected Parameter _dishes;
    [SerializeField] protected int _dishesCost;

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;
    
    private void OnEnable()
    {
        SetButtonText();
    }

    public override void DoAction()
    {
        base.DoAction();
        _dishes.AddValue(_dishesCost);
        _actions.CheckActionsState();
        SetButtonText();
    }

    public void SetButtonText()
    {
        if (_button.interactable == true)
            _buttonText.text = "Wash the dishes";
        else
        {
            if (_dishes.CurrentValue == _dishes.MaxValue)
                _buttonText.text = "All dishes clean";
            else if (_dishes.CurrentValue == _dishes.MaxValue - 1)
                _buttonText.text = "Seriously? Just one dish";
            else
                _buttonText.text = "Too tired";
        }
    }

    protected override bool IsEqualCondition()
    {
        return _dishes.CurrentValue < _dishes.MaxValue - 1;
    }
}