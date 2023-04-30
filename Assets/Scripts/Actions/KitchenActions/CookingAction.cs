using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookingAction : SimpleAction
{
    [SerializeField] protected Parameter _dishes;

    [SerializeField] protected int _dishesCost;
    [SerializeField] private CookingPanel _cookingPanel;

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;

    protected FoodRecipe _currentRecipe;

    public override void DoAction()
    {
        _currentRecipe = _cookingPanel.CurrentRecipe;

        base.DoAction();
        
        _dishes.ReduceValue(_dishesCost);
        _currentRecipe.ChangeFoodCount(1);

        _cookingPanel.UpdateFoodCount(_currentRecipe.FoodCount);
        _actions.CheckActionsState();
        _cookingPanel.SetRecipe(_cookingPanel.CurrentRecipe);
        SetButtonText();
    }

    public void SetButtonText()
    {
        if (_button.interactable == true)
            _buttonText.text = "Cook";

        else
        {
            if (_dishes.CurrentValue == 0)
                _buttonText.text = "Everything is dirty";

            if (_spoons.CurrentValue == 0)
                _buttonText.text = "Too tired";
        }
    }

    public void SetCost(FoodRecipe recipe)
    {
        _currentRecipe = recipe;
        _minutesActionCost = _currentRecipe.TimeCooking;
        _actionHungerCost = _currentRecipe.HungerCost;
        _actionSpoonsCost = _currentRecipe.SpoonsCost;
        _actionHungerCost = _currentRecipe.HygieneCost;
    }

    protected override bool IsEqualCondition()
    {
        return _dishes.CurrentValue >= _dishesCost;
    }
}