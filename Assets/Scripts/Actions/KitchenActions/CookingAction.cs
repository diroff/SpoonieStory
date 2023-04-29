using UnityEngine;

public class CookingAction : SimpleAction
{
    [SerializeField] protected Parameter _dishes;

    [SerializeField] protected int _dishesCost;
    [SerializeField] private CookingPanel _cookingPanel;

    protected FoodRecipe _currentRecipe;

    public override void DoAction()
    {
        _currentRecipe = _cookingPanel.CurrentRecipe;

        base.DoAction();
        
        _dishes.ReduceValue(_dishesCost);
        _currentRecipe.ChangeFoodCount(1);

        _cookingPanel.UpdateFoodCount(_currentRecipe.FoodCount);
        _actions.CheckActionsState();
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