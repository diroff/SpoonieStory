using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyController : MonoBehaviour
{
    [SerializeField] private List<LessonSchedule> _lessonSchedules;
    [SerializeField] private TimeManagment _timeManagment;

    public LessonSchedule CheckSchedule()
    {
        foreach (LessonSchedule schedule in _lessonSchedules)
        {
            Debug.Log("Current lesson starts in " + schedule.HoursStarted + ":" + schedule.MinutesStarted);

            if (_timeManagment.CurrentHours >= schedule.HoursStarted && _timeManagment.CurrentHours <= schedule.HoursFinished)
            {
                if (schedule.HoursStarted == _timeManagment.CurrentHours)
                {
                    Debug.Log("Now is first hour");
                    if (_timeManagment.CurrentMinutes >= schedule.MinutesStarted)
                    {
                        return schedule;
                    }
                }

                if (schedule.HoursFinished == _timeManagment.CurrentHours)
                {
                    Debug.Log("Now is last hour");
                    if (_timeManagment.CurrentMinutes < schedule.MinutesFinished)
                    {
                        return schedule;
                    }
                    else
                        continue;
                }

                Debug.Log("Now is not first && is not last hour");
                return schedule;
            }
        }

        Debug.Log("No schedule now");
        return null;
    }
}
