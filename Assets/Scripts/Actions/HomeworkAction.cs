using UnityEngine;

public class HomeworkAction : SimpleAction
{
    [SerializeField] private StudyController _studyController;

    public override void DoAction()
    {
        base.DoAction();
        _studyController.DoHomework();
        _actions.CheckActionsState();
    }

    protected override bool IsEqualCondition()
    {
        return !_studyController.HomeWorkIsReady;
    }
}
