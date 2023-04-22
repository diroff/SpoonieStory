using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishesAction : CookingAction
{
    protected override bool IsEqualCondition()
    {
        return _dishes.MaxValue - _dishes.CurrentValue >= -_dishesCost;
    }
}
