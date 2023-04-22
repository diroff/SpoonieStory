using UnityEngine;

public class EatAction : CookingAction
{
    protected override bool IsEqualCondition()
    {
        if (!base.IsEqualCondition())
            return false;

        return _food.CurrentValue > 0;
    }
}