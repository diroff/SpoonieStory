using UnityEngine;

public class BathroomAction : SimpleAction
{
    [SerializeField] private bool UsedOnVisit = false;

    public void Used(bool used)
    {
        UsedOnVisit = used;
    }

    public override void DoAction()
    {
        base.DoAction();
        Used(true);
        _actions.CheckActionsState();
    }

    protected override bool IsEqualCondition()
    {
        return !UsedOnVisit;
    }
}