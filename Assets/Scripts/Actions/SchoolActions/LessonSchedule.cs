using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonSchedule : MonoBehaviour
{
    [SerializeField] private Room _room;
    [SerializeField] private int _hoursStarted;
    [SerializeField] private int _minutesStarted;

    [SerializeField] private int _hoursFinished;
    [SerializeField] private int _minutesFinished;

    public Room Room => _room;
    public int HoursStarted => _hoursStarted;
    public int MinutesStarted => _minutesStarted;
    public int HoursFinished => _hoursFinished;
    public int MinutesFinished => _minutesFinished;
}