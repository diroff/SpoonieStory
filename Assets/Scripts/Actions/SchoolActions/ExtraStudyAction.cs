using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraStudyAction : SimpleAction
{
    [SerializeField] private EmotionController _emotions;

    public override void DoAction()
    {
        if (_emotions.Bored.IsActive)
            _actionSpoonsCost++;
        if (_emotions.Attentive.IsActive)
            _actionSpoonsCost--;

        base.DoAction();

        if (_emotions.Bored.IsActive)
            _actionSpoonsCost--;
        if (_emotions.Attentive.IsActive)
            _actionSpoonsCost++;

        _actions.CheckActionsState();
    }
}