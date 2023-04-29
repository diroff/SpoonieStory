using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishesAction : SimpleAction
{
    [SerializeField] protected Parameter _dishes;
    [SerializeField] protected int _dishesCost;

    public override void DoAction()
    {
        base.DoAction();
        _dishes.AddValue(_dishesCost);
        _actions.CheckActionsState();
    }

    protected override bool IsEqualCondition()
    {
        return _dishes.CurrentValue < _dishes.MaxValue - 1;
    }
}
