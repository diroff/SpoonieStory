using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenAction : SimpleAction
{
    [SerializeField] private Parameter _dishes;
    [SerializeField] private int _dishesCost;

    protected override bool IsEqualCondition()
    {
        return _dishes.CurrentValue >= _dishesCost;
    }
}