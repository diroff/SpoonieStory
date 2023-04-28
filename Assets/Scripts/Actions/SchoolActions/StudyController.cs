using System.Collections.Generic;
using UnityEngine;

public class StudyController : MonoBehaviour
{
    [SerializeField] private List<LessonSchedule> _lessonSchedules;
    [SerializeField] private TimeManagment _timeManagment;
    [SerializeField] private LessonSchedule _waitRoom;
    [Space]
    [SerializeField] private Grade _grade;
    [SerializeField] private bool _homeWorkReady;
    [SerializeField] private bool _wasOnSchool = false;

    public bool HomeWorkIsReady => _homeWorkReady;

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
            Debug.Log("Current lesson starts in " + schedule.HoursStarted + ":" + schedule.MinutesStarted);

            if (_timeManagment.CurrentHours >= schedule.HoursStarted && _timeManagment.CurrentHours <= schedule.HoursFinished)
            {
                if (schedule.HoursStarted == schedule.HoursFinished && _timeManagment.CurrentHours == schedule.HoursStarted)
                {
                    if (_timeManagment.CurrentMinutes >= schedule.MinutesStarted && _timeManagment.CurrentMinutes < schedule.MinutesFinished)
                        return schedule;
                }

                else if (schedule.HoursStarted == _timeManagment.CurrentHours)
                {
                    if (_timeManagment.CurrentMinutes >= schedule.MinutesStarted)
                        return schedule;
                }

                else if (schedule.HoursFinished == _timeManagment.CurrentHours)
                {
                    if (_timeManagment.CurrentMinutes < schedule.MinutesFinished)
                        return schedule;
                }
            }
        }

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

    public void DoHomework()
    {
        _homeWorkReady = true;
    }

    public void WasInSchool(bool was)
    {
        _wasOnSchool = was;
    }

    private void SchoolEnded()
    {
        if (_homeWorkReady && _wasOnSchool)
            _grade.AddValue(1);
        else if(!_homeWorkReady && _wasOnSchool)
            _grade.ReduceValue(2);
        else
            _grade.ReduceValue(4);

        _homeWorkReady = false;
    }
}