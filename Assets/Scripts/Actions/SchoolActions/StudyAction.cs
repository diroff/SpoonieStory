using UnityEngine;

public class StudyAction : SimpleAction
{
    [SerializeField] private StudyController _studyController;
    [SerializeField] private RoomController _roomController;

    public override void DoAction()
    {
        base.DoAction();

        LessonSchedule schedule = _studyController.CheckSchedule();

        if (schedule != null)
            _roomController.OpenRoom(schedule.Room);
        else
            Debug.Log("Schedule is empty!");

    }
}
