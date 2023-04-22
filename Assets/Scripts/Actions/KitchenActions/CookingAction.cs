using UnityEngine;

public class CookingAction : SimpleAction
{
    [SerializeField] protected Parameter _dishes;
    [SerializeField] protected Parameter _food;

    [SerializeField] protected int _dishesCost;
    [SerializeField] protected int _foodCost;

    public override void DoAction()
    {
        base.DoAction();

        if (_dishesCost > 0)
            _dishes.ReduceValue(_dishesCost);
        else if (_dishesCost < 0)
            _dishes.AddValue(-_dishesCost);

        if (_foodCost > 0)
            _food.ReduceValue(_foodCost);

        else if (_foodCost < 0)
            _food.AddValue(-_foodCost);

        _actions.CheckActionsState();
    }

    protected override bool IsEqualCondition()
    {
        return _dishes.CurrentValue >= _dishesCost;
    }
}