using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAction : SimpleAction
{
    [SerializeField] private SleepEvent _sleepEvent;

    public override void DoAction()
    {
        base.DoAction();
        _sleepEvent.CalculateSpoonsCount(_hoursSpent);
        _actions.CheckActionsState();
    }
}