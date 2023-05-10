using System.Collections.Generic;
using UnityEngine;

public class Lessons : MonoBehaviour
{
    [SerializeField] private List<Lesson> _lessons;
    [SerializeField] private Parameter _spoons;

    public void ResetLessons()
    {
        foreach (Lesson lesson in _lessons)
            lesson.UnVisitLesson();
    }

    public void StopLastEffect()
    {
        foreach (Lesson lesson in _lessons)
        {
            lesson.Actions.CheckActionsState();
            _spoons.ReduceValue(lesson.LessonCounter);
            lesson.LessonCounter = 0;
            lesson.StopEffects();
        }
    }
}