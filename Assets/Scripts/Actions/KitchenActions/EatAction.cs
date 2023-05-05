using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EatAction : SimpleAction
{
    [SerializeField] protected Parameter _dishes;

    [SerializeField] protected int _dishesCost;
    [SerializeField] private CookingPanel _cookingPanel;

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private Effects _effects;

    [SerializeField] private Alert _eatingAlert;

    protected FoodRecipe _currentRecipe;

    private void OnEnable()
    {
        _currentRecipe = _cookingPanel.CurrentRecipe;
    }

    public override void DoAction()
    {
        _currentRecipe = _cookingPanel.CurrentRecipe;

        base.DoAction();

        _dishes.ReduceValue(_dishesCost);
        _currentRecipe.ChangeFoodCount(-1);

        _cookingPanel.UpdateFoodCount(_currentRecipe.FoodCount);
        _effects.EatingEffect.MakeEffect();
        AlertController.Alerts.ShowAlert(_eatingAlert);

        _actions.CheckActionsState();
        _cookingPanel.SetRecipe(_cookingPanel.CurrentRecipe);
    }


    public void SetButtonText()
    {
        if (_button.interactable == true)
            _buttonText.text = "Eat";

        else
        {
            if(_currentRecipe.FoodCount == 0)
                _buttonText.text = "Nothing to eat";
            if (_dishes.CurrentValue == 0)
                _buttonText.text = "Everything is dirty";

            if (_spoons.CurrentValue == 0)
                _buttonText.text = "Too tired";
        }

    }

    public void SetCost(FoodRecipe recipe)
    {
        _currentRecipe = recipe;
        _minutesActionCost = _currentRecipe.TimeEating;
        _actionHungerCost = -_currentRecipe.Hunger;

        _actionHygieneCost = _currentRecipe.HygieneCost;
    }

    protected override bool IsEqualCondition()
    {
        if (_currentRecipe == null)
            return false;

        return _dishes.CurrentValue >= _dishesCost && _currentRecipe.FoodCount > 0;
    }
}