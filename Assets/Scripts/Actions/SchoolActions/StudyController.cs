using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyController : MonoBehaviour
{
    [SerializeField] private List<LessonSchedule> _lessonSchedules;
    [SerializeField] private TimeManagment _timeManagment;
    [SerializeField] private LessonSchedule _waitRoom;

    public LessonSchedule CheckSchedule()
    {
        foreach (LessonSchedule schedule in _lessonSchedules)
        {
            Debug.Log("Current lesson starts in " + schedule.HoursStarted + ":" + schedule.MinutesStarted);

            if (_timeManagment.CurrentHours >= schedule.HoursStarted && _timeManagment.CurrentHours <= schedule.HoursFinished)
            {
                if(schedule.HoursStarted == schedule.HoursFinished && _timeManagment.CurrentHours == schedule.HoursStarted)
                {
                    if (_timeManagment.CurrentMinutes >= schedule.MinutesStarted && _timeManagment.CurrentMinutes < schedule.MinutesFinished)
                    {
                        Debug.Log("1 hour and current minutes");
                        return schedule;
                    }
                }

                else  if (schedule.HoursStarted == _timeManagment.CurrentHours)
                {
                    if (_timeManagment.CurrentMinutes >= schedule.MinutesStarted)
                    {
                        Debug.Log("First hour and current minute >= started minute:" + _timeManagment.CurrentMinutes + ">=" + schedule.MinutesStarted);
                        return schedule;
                    }
                }

                else if (schedule.HoursFinished == _timeManagment.CurrentHours)
                {
                    if (_timeManagment.CurrentMinutes < schedule.MinutesFinished)
                    {
                        Debug.Log("Last hour and current minute < finished minute" + _timeManagment.CurrentMinutes + "<" + schedule.MinutesFinished);
                        return schedule;
                    }
                }
            }
        }

        Debug.Log("No schedule now");
        return _waitRoom;
    }
}
