using UnityEngine;

public class StudyAction : SimpleAction
{
    [Header("Study")]
    [SerializeField] protected StudyController _studyController;
    [SerializeField] private RoomController _roomController;
    [Space]
    [SerializeField] private Grade _grade;
    [SerializeField] private int _additionalGrade;

    public override void DoAction()
    {
        base.DoAction();
        _grade.AddValue(_additionalGrade);

        LessonSchedule schedule = _studyController.CheckSchedule();
        
        _roomController.OpenRoom(schedule.Room);
    }
}