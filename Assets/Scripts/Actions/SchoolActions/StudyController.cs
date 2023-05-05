using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StudyController : MonoBehaviour
{
    [SerializeField] private List<LessonSchedule> _lessonSchedules;
    [SerializeField] private TimeManagment _timeManagment;
    [SerializeField] private RoomController _roomController;
    [SerializeField] private LessonSchedule _waitRoom;
    [SerializeField] private LessonSchedule _lateRoom;

    [Space]
    [SerializeField] private Grade _grade;
    [SerializeField] private bool _homeWorkReady;
    [SerializeField] private bool _wasOnSchool = false;
    [SerializeField] private Effects _effects;

    [Header("Alerts")]
    [SerializeField] private Alert _lateAlert;
    [SerializeField] private Alert _classesOverAlert;
    [SerializeField] private Alert _skippingLessonsAlert;
    [SerializeField] private Alert _homeworkDoneAlert;
    [SerializeField] private Alert _homeworkUnDoneAlert;
    [SerializeField] private Alert _newHomeworkAlert;

    private bool _nowIsLesson = false;

    public LessonSchedule WaitRoom => _waitRoom;
    public bool HomeWorkIsReady => _homeWorkReady;

    public UnityEvent<bool> HomeworkFinished;

    private void OnEnable()
    {
        _timeManagment.SchoolEnded.AddListener(SchoolEnded);
    }

    private void OnDisable()
    {
        _timeManagment.SchoolEnded.RemoveListener(SchoolEnded);
    }

    public LessonSchedule CheckSchedule()
    {
        WasInSchool(true);

        foreach (LessonSchedule schedule in _lessonSchedules)
        {
            if (_timeManagment.CurrentHours >= schedule.HoursStarted && _timeManagment.CurrentHours <= schedule.HoursFinished)
            {
                if (schedule.HoursStarted == schedule.HoursFinished && _timeManagment.CurrentHours == schedule.HoursStarted)
                {
                    if (_timeManagment.CurrentMinutes >= schedule.MinutesStarted && _timeManagment.CurrentMinutes < schedule.MinutesFinished)
                    {
                        _nowIsLesson = true;
                        return schedule;
                    }
                }

                else if (schedule.HoursStarted == _timeManagment.CurrentHours)
                {
                    if (_timeManagment.CurrentMinutes >= schedule.MinutesStarted)
                    {
                        _nowIsLesson = true;
                        return schedule;
                    }
                }

                else if (schedule.HoursFinished == _timeManagment.CurrentHours)
                {
                    if (_timeManagment.CurrentMinutes < schedule.MinutesFinished)
                    {
                        _nowIsLesson = true;
                        return schedule;
                    }
                }
            }
        }

        _nowIsLesson = false;
        return _waitRoom;
    }

    public void WaitNextLesson()
    {
        if (!CheckSchedule() == _waitRoom)
            return;

        _timeManagment.SpendTime(0, 30);

        var currentLesson = CheckSchedule();

        if(currentLesson == _waitRoom)
        {
            _timeManagment.SpendTime(0, 20);
            currentLesson = CheckSchedule();
        }

        _timeManagment.SetTime(currentLesson.HoursStarted, currentLesson.MinutesStarted);
    }

    public void VisitSchool()
    {
        if (IsLessonStartedLongAgo())
        {
            _roomController.OpenRoom(_lateRoom.Room);
            AlertController.Alerts.ShowAlert(_lateAlert);
        }
        else
            _roomController.OpenRoom(CheckSchedule().Room);
    }

    public bool IsLessonStartedLongAgo()
    {
        LessonSchedule schedule = CheckSchedule();

        if (!_nowIsLesson)
            return false;

        int minutesFromStart = 0;

        if (schedule.HoursStarted == schedule.HoursFinished)
            minutesFromStart = _timeManagment.CurrentMinutes - schedule.MinutesStarted;

        else if(schedule.HoursStarted < schedule.HoursFinished)
        {
            if (schedule.HoursStarted == _timeManagment.CurrentHours)
                minutesFromStart = _timeManagment.CurrentMinutes - schedule.MinutesStarted;
            else
                minutesFromStart = (60 - schedule.MinutesStarted) + _timeManagment.CurrentMinutes;
        }

        Debug.Log("Time from lesson started:" + minutesFromStart);

        if (minutesFromStart >= 15)
            return true;
        else
            return false;
    }

    public void DoHomework()
    {
        _homeWorkReady = true;
        HomeworkFinished?.Invoke(_homeWorkReady);
    }

    public void WasInSchool(bool was)
    {
        _wasOnSchool = was;
    }

    private void SchoolEnded()
    {
        if (TodayIsWeekend())
            return;

        if (_homeWorkReady && _wasOnSchool)
        {
            _grade.AddValue(1);
            AlertController.Alerts.ShowAlert(_homeworkDoneAlert);
            _effects.HomeworkDoneEffect.MakeEffect();
        }
        else if(!_homeWorkReady && _wasOnSchool)
        {
            AlertController.Alerts.ShowAlert(_homeworkUnDoneAlert);
            Debug.Log("Undone");
            _grade.ReduceValue(2);
        }
        else
        {
            AlertController.Alerts.ShowAlert(_skippingLessonsAlert);
            _effects.SkippedClassesEffect.MakeEffect();
            _grade.ReduceValue(4);
        }

        _homeWorkReady = false;

        if (_wasOnSchool)
            AlertController.Alerts.ShowAlert(_classesOverAlert);

        HomeworkFinished?.Invoke(_homeWorkReady);
        AlertController.Alerts.ShowAlert(_newHomeworkAlert);
    }

    private bool TodayIsWeekend()
    {
        return _timeManagment.CurrentWeekDay == "Saturday" || _timeManagment.CurrentWeekDay == "Sunday";
    }
}