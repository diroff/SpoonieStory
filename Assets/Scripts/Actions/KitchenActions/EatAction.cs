using UnityEngine;

public class EatAction : SimpleAction
{
    [SerializeField] protected Parameter _dishes;

    [SerializeField] protected int _dishesCost;
    [SerializeField] private CookingPanel _cookingPanel;

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
        _actions.CheckActionsState();
    }

    public void SetCost(FoodRecipe recipe)
    {
        _currentRecipe = recipe;
        _minutesActionCost = _currentRecipe.TimeEating;
        _changeValue = _currentRecipe.Hunger;
        _actionHygieneCost = _currentRecipe.HygieneCost;
    }

    protected override bool IsEqualCondition()
    {
        if (_currentRecipe == null)
            return false;

        return _dishes.CurrentValue >= _dishesCost && _currentRecipe.FoodCount > 0;
    }
}