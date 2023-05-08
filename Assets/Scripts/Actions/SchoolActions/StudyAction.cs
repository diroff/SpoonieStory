using UnityEngine;

public class StudyAction : SimpleAction
{
    [Header("Study")]
    [SerializeField] protected StudyController _studyController;
    [SerializeField] private RoomController _roomController;
    [Space]
    [SerializeField] private Grade _grade;
    [SerializeField] private int _additionalGrade;
    [SerializeField] private bool _hided = true;

    public override void DoAction()
    {
        base.DoAction();
        _grade.AddValue(_additionalGrade);

        LessonSchedule schedule = _studyController.CheckSchedule();
        
        _roomController.OpenRoom(schedule.Room);
        _actions.CheckActionsState();
    }

    protected override bool IsEqualCondition()
    {
        if(_hided)
            return _spoons.CurrentValue > 1;
        else
            return true;
    }
}