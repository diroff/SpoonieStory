using UnityEngine;

public class HomeworkAction : SimpleAction
{
    [SerializeField] private StudyController _studyController;
    [SerializeField] private EmotionController _emotions;

    public override void DoAction()
    {
        if (_emotions.Bored.IsActive)
            _actionSpoonsCost++;
        if(_emotions.Attentive.IsActive)
            _actionSpoonsCost--;

        base.DoAction();
        _studyController.DoHomework();

        if (_emotions.Bored.IsActive)
            _actionSpoonsCost--;
        if (_emotions.Attentive.IsActive)
            _actionSpoonsCost++;

        _actions.CheckActionsState();
    }

    public void CheckHomeWorkStatus()
    {
        _actions.CheckActionsState();
    }

    protected override bool IsEqualCondition()
    {
        return !_studyController.HomeWorkIsReady;
    }
}
